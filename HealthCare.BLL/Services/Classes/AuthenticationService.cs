using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;


namespace HealthCare.BLL.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<ApplicationUser> _singInManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IEmailSender emailSender,
            SignInManager<ApplicationUser> singInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
            _singInManager = singInManager;
        }
        public async Task<string> ConfirmEmail(string token, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return " email confirmed successfully";
            }

            return "email confirmation failed";
        }

        public Task<bool> ForgotPassword(ForgotPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }
            var result = await _singInManager.CheckPasswordSignInAsync(user, loginRequest.Password, true);
            if (result.Succeeded)
            {
                return new UserResponse
                {
                    Token = await CreateTokenAsync(user)
                };
            }
            else if (result.IsLockedOut)
            {
                throw new Exception("your account is locked");
            }
            //confirmed email
            else if (result.IsNotAllowed)
            {
                throw new Exception("please confirm your email");
            }
            else
            {
                throw new Exception("Invalid email or password");

            }
        }

        public async Task<UserResponse> RegisterAsync(RegisterRequest registerRequest, HttpRequest httpRequest)
        {
            var user = new ApplicationUser()
            {
                FullName = registerRequest.FullName,
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.PhoneNumber,
                UserName = registerRequest.UserName
            };
            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var escapeToken = Uri.EscapeDataString(token);
                var emailurl = $"{httpRequest.Scheme}://{httpRequest.Host}/api/identity/Accounts/ConfirmEmail?token={escapeToken}&userid={user.Id}";
                await _emailSender.SendEmailAsync(user.Email, "NTier Shop - Confrim your email", $"<h1> Hello {user.UserName}</h1>" +
                    $"<a href='{emailurl}'> confirm </a>");

                //add customer role to the created users
                await _userManager.AddToRoleAsync(user, "Customer");
                return new UserResponse()
                {
                    Token = registerRequest.Email
                };
            }
            else
            {
                throw new Exception($"{result.Errors}");
            }
        }

        public Task<bool> ResetPassword(ResetPasswordRequest request)
        {
            throw new NotImplementedException();
        }
        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var Roles = await _userManager.GetRolesAsync(user);
            foreach (var role in Roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }
            // var secretKey = "ojbakcNgKARgp6V0lZulePr24crglUfz";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("jwtOptions")["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials

                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
