using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.Models
{
    public class Invoice
    {

        public int Id { get; set; }
        public string FinanceId { get; set; }
        public int VisitId { get; set; }
        public decimal TotalAmount { get; set; } = 0;
        public DateTime? ReviewedAt { get; set; }

        public ApplicationUser? Finance { get; set; }
        public required Visit Visit { get; set; } 

    }
}
