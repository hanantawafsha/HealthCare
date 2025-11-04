using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.Models
{
    
    public class Visit
    {


        public int Id { get; set; }


        // Required link to Appointment
        public int AppointmentId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public EncounterStatus Status { get; set; } = EncounterStatus.InProgress;
        public string? ClinicalNotes { get; set; }

        // Navigation property
        public Appointment Appointment { get; set; } = null!;
        public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();


    }
}
