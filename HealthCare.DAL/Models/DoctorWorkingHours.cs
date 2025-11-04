using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.DAL.Models
{
    public class DoctorWorkingHours
    {

        public int Id { get; set; }
        public string DoctorId { get; set; }
        public DayOfWeekEnum Weekday { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public ApplicationUser Doctor { get; set; } = null!;

    }
}
