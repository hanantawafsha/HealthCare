using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime? PasswordResetCodeExpire { get; set; }
        public string? CodeResetPassword { get; set; }

        // doctor 
        public int? SlotMinutes { get; set; }
        public string? DoctorSpecialization { get; set; }

        // Patient-specific
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }

        //address relationship
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        //appointment relationship 
        public virtual ICollection<Appointment>? DoctorAppointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Appointment>? PatientAppointments { get; set; } = new List<Appointment>();
        public virtual ICollection<DoctorWorkingHours> DoctorWorkingHours { get; set; } = new List<DoctorWorkingHours>();
    }
}
