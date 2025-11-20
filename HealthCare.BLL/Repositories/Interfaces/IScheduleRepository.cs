using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        Task<DoctorWorkingHours?> GetDoctorWorkingHoursAsync(string doctorId, DayOfWeekEnum day);
        Task<ApplicationUser?> GetDoctorAsync(string doctorId);
        Task<List<Appointment>> GetDoctorAppointmentsForDateAsync(string doctorId, DateTime date);
    }
}
