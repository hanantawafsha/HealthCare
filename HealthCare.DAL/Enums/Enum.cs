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
            Sunday, //0
            Monday, //1
            Tuesday, //2
            Wednesday, //3
            Thursday, //4
            Friday, //5
            Saturday //6
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
