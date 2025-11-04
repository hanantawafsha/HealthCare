using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.Enums
{
    public class Enum
    {
        public enum UserRole
        {
            Patient,
            Doctor,
            Finance,
            Admin
        }

        public enum DayOfWeekEnum
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        public enum AppointmentStatus
        {
            Booked,
            Cancelled,
            Fulfilled
        }

        public enum VisitType
        {
            InClinic,
            FollowUp,
            Consultation
        }
        //visit status
        public enum EncounterStatus
        {
            Planned,
            InProgress,
            Completed,
            Cancelled
        }
    }
}
