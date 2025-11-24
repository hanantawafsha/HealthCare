using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
       // public int DoctorWorkingHoursId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Booked;
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        public VisitType? Type { get; set; }

        //navigation properties 
        public virtual ApplicationUser? Patient { get; set; }
        public virtual ApplicationUser? Doctor { get; set; } 
       // public virtual DoctorWorkingHours? DoctorWorkingHours { get; set; }
        public Visit? Visit { get; set; }
    }
}

