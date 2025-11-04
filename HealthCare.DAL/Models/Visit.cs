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
        public int Id { get; set; }
        //Doctor relation
        public string DoctorId { get; set; }
        public virtual ApplicationUser? Doctor { get; set; }

        //Patient relation

        public string PatientId { get; set; }
        public virtual ApplicationUser? Patient { get; set; }

        public string Notes { get; set; } = string.Empty;

        //treatment relation
        public virtual ICollection <Treatment>? Treatments { get; set; } = new List<Treatment>();
        //finance 
        public decimal TotalAmount { get; set; }

        public VisitStatus Status { get; set; } = VisitStatus.Pending;

        //appointment relation 
        [ForeignKey("Appointment")]

        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }





    }
}
