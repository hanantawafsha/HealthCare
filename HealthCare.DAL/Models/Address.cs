using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        //public string? UserId { get; set; }
        //relationship to Application user - navigation properties 
        public ApplicationUser? User { get; set; }

    }
}
