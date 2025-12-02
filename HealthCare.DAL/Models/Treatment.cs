using HealthCare.DAL.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        [CustomLengthAttribute(5,10)]
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        //visit relationship - navigation properties 
        public int VisitId { get; set; }
        public Visit Visit { get; set; }
    }
}
