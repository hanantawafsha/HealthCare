using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.DTO.Responses
{
    public class AppointmentResponseDto
    {

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        public VisitType? Type { get; set; }
        public UserResponseDto Doctor { get; set; } = null!;
        public UserResponseDto Patient { get; set; } = null!;

    }
}
