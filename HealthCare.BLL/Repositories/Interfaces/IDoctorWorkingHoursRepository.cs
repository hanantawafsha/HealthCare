using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Repositories.Interfaces
{
    public interface IDoctorWorkingHoursRepository:IGenericRepository<DoctorWorkingHours>
    {
        Task<IEnumerable<DoctorWorkingHours>> GetWorkingHoursByDoctorAsync(string doctorId);
        Task<IEnumerable<DoctorWorkingHours>> GetWorkingHoursByDoctorAndDayAsync(string doctorId, DayOfWeekEnum day);
    }
}
