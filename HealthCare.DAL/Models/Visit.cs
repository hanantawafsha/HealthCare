using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.Models
{
    public enum VisitStatus
    {
        Pending = 0,
        Canceled = 1,
        Approved = 2,
        InProgress  = 3,
        Done = 4,
        Delayed = 5,


    }
    public class Visit
    {
        //Doctor relation
        public string DoctorId { get; set; }
        public ApplicationUser? Doctor { get; set; }

        //Patient relation

        public string PatientId { get; set; }
        public ApplicationUser? Patient { get; set; }

        public string Notes { get; set; } = string.Empty;

        //treatment relation
        public List<Treatment>? Treatments { get; set; }
        //finance 
        public decimal TotalAmount { get; set; }

        public VisitStatus Status { get; set; } = VisitStatus.Pending;

        //appointment relation 
        [ForeignKey("Appointment")]

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }





    }
}
