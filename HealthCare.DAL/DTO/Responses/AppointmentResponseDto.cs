using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.DTO.Responses
{
    public class AppointmentResponseDto
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentStatus Status { get; set; }
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VisitType? Type { get; set; }
        // Status = Enum.GetName(typeof(AppointmentStatus), appointment.Status) convert it to string


    }
}
