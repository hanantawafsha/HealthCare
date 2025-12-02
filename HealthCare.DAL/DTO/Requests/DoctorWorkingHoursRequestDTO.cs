using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.DTO.Requests
{
    public class DoctorWorkingHoursRequestDTO
    {

        // public required string DoctorId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DayOfWeekEnum Weekday { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
