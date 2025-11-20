using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.Utilities
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedData(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task DataSeedingAsync()
        {
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                await _context.Database.MigrateAsync();
            }

        }

        public async Task IdentityDataSeedingAsync()
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(
                      new IdentityRole("Admin"));
                await _roleManager.CreateAsync(
                    new IdentityRole("Patient"));
                await _roleManager.CreateAsync(
                    new IdentityRole("Doctor"));
                await _roleManager.CreateAsync(
                    new IdentityRole("Finance"));
            }
            if (!await _userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser()
                {
                    Email = "hananjtawafsha@gmail.com",
                    FullName = "Hanan Admin",
                    PhoneNumber = "0598458868",
                    UserName = "htawafshaAdmin",
                    EmailConfirmed = true,

                };

                await _userManager.CreateAsync(user1, "Hanan@123");
                // force confirm
                user1.EmailConfirmed = true;
                await _userManager.AddToRoleAsync(user1, "Admin");
            }
            await _context.SaveChangesAsync();
        }
    }
}
