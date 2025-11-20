using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.DTO.Requests
{
    public class VisitRequestDTO
    {
        public int AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public EncounterStatus Status { get; set; } = EncounterStatus.InProgress;
        public string? ClinicalNotes { get; set; }
    }
}
