using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.DTO.Requests
{
    public class InvoiceRequestDTO
    {
        //public string FinanceId { get; set; }
        public int VisitId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? ReviewedAt { get; set; }


    }
}
