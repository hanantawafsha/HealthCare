using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.DTO.Requests
{
    public class DoctorWorkingHoursRequestDTO
    {

        public required string DoctorId { get; set; }
        public DayOfWeekEnum Weekday { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
