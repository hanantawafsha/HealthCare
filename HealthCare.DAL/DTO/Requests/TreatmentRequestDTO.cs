using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.DTO.Requests
{
    public class TreatmentRequestDTO
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        //public int VisitId { get; set; }

    }
}
