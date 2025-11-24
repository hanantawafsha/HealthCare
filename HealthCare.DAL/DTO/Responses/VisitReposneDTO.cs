using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.DTO.Responses
{
    public class VisitReposneDTO
    {

        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; } 
        public string? ClinicalNotes { get; set; }
        //Treatment DTO 
        public List<TreatmentResponseDTO> Treatments { get; set; } = new List<TreatmentResponseDTO>();


    }
}
