using HealthCare.BLL.Repositories.Classes;
using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Classes;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.BLL.Services.Utilities;
using HealthCare.DAL.Utilities;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace HealthCare.PL
{
    internal static class AppConfiguration
    {
        public static void AddConfig(this IServiceCollection services)
        {
            //Services 
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEmailSender, EmailSetting>();
            services.AddScoped<IDoctorWorkingHoursService, DoctorWorkingHoursService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ITreatmentSerivce,TreatmentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVisitService, VisitService>();


            //Repositories 
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorWorkingHoursRepository, DoctorWorkingHoursRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<ISeedData, SeedData>();


        }
    }
}
