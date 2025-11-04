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
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public string Departments { get; set; }
        public string DoctorSpecialization { get; set; }
        //visit relationship 
        public List<Visit>? DoctorVisits { get; set; }
        public List<Visit>? PatientVisits { get; set; }

    }
}
