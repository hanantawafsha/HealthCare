
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthCare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //allow any origin
            var userPolicy = "";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: userPolicy, policy =>
                {
                    policy.AllowAnyOrigin();
                });
            });
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(Options =>
            {
                Options.Password.RequiredLength = 8;
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireDigit = true;
                Options.Password.RequireLowercase = true;
                Options.User.RequireUniqueEmail = true;

                Options.SignIn.RequireConfirmedEmail = true;
                Options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                Options.Lockout.MaxFailedAccessAttempts = 5;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
