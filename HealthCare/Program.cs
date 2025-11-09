
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using HealthCare.PL;
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

            //add services and repositories 
            builder.Services.AddConfig();
            //allow any origin
            var userPolicy = "";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: userPolicy, policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            var connectionString = (builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(" Connection String"
                + "'DefaultConnection' not found."));

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(connectionString));

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

            //service
            //authentication
            //+jwt 
            //stripe

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();
            app.MapControllers();

            app.Run();
        }
    }
}
