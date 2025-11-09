using HealthCare.BLL.Services.Classes;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.BLL.Services.Utilities;
using HealthCare.BLL.Repositories.Classes;
using HealthCare.BLL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace HealthCare.PL
{
    internal static class AppConfiguration
    {
        public static void AddConfig(this IServiceCollection services)
        {
            //Services 
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
          //  services.AddScoped<IEmailSender, EmailSetting>();


            //Repositories 
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
