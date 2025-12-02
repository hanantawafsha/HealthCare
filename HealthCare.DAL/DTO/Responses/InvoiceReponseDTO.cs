using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.DTO
{
    public class InvoiceReponseDTO
    {

        public int Id { get; set; }
        public string FinanceId { get; set; }
        public int VisitId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? ReviewedAt { get; set; }

        public string? FinanceName { get; set; }
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
    }
}
