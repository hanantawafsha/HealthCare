using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Repositories.Classes
{
    public class ScheduleRepository : IScheduleRepository
    {
        public Task<List<Appointment>> GetDoctorAppointmentsForDateAsync(string doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetDoctorAsync(string doctorId)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorWorkingHours?> GetDoctorWorkingHoursAsync(string doctorId, DAL.Enums.Enum.DayOfWeekEnum day)
        {
            throw new NotImplementedException();
        }
    }
}
