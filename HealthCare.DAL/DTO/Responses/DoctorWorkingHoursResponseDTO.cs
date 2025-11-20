using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.DTO.Responses
{
    public class DoctorWorkingHoursResponseDTO
    {

        public int Id { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; } 
        public DayOfWeekEnum Weekday { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
