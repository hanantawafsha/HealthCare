using HealthCare.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.DTO.Requests
{
    public class AppointmentRequestDto
    {

       // public string PatientId { get; set; }
       // public string DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentStatus Status { get; set; } //= AppointmentStatus.Booked;
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VisitType? Type { get; set; }
    }
}
