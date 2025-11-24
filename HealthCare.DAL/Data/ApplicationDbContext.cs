using HealthCare.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorWorkingHours> DoctorWorkingHours { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Rename Identity tables
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");


            //ignore identity tables 
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();

            //custom tables
            //relations 
            builder.Entity<Appointment>()
               .HasOne(v => v.Doctor)
               .WithMany(u => u.DoctorAppointments)
               .HasForeignKey(v => v.DoctorId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(v => v.Patient)
                .WithMany(u => u.PatientAppointments)
                .HasForeignKey(v => v.PatientId)
                .OnDelete(DeleteBehavior.Restrict);


            //doctor working hours with users 1tom

            builder.Entity<DoctorWorkingHours>()
        .HasOne(d => d.Doctor)
        .WithMany(d => d.DoctorWorkingHours)
        .HasForeignKey(d => d.DoctorId)
        .OnDelete(DeleteBehavior.NoAction);


            //address - user one to one 

            builder.Entity<ApplicationUser>()
    .HasOne(u => u.Address)
    .WithOne(a => a.User)
    .HasForeignKey<ApplicationUser>(u => u.AddressId)
    .OnDelete(DeleteBehavior.Restrict);

           


        }





    }

}
