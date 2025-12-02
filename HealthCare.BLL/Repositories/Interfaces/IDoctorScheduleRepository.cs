using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Repositories.Interfaces
{
    public interface IDoctorScheduleRepository
    {
        Task<ApplicationUser> GetDoctorAsync(string doctorId);

        Task<List<DoctorWorkingHours>> GetWorkingHoursAsync(string doctorId,DayOfWeekEnum day);

        Task<List<Appointment>> GetDoctorAppointmentsAsync(string doctorId,DateTime date);
        //Task<bool> HasWorkingHoursAsync(string doctorId, DayOfWeekEnum weekday);
    }
}
