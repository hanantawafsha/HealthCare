using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;

namespace HealthCare.BLL.Repositories.Interfaces
{
    public interface IDoctorWorkingHoursRepository:IGenericRepository<DoctorWorkingHours>
    {
        Task<List<DoctorWorkingHoursResponseDTO>> GetDoctorWorkingSlotsAsync(string doctorId);
        Task<int> AddWorkingHoursAsync(DoctorWorkingHoursDto doctorWorkingHrs, string doctorId);
        Task<List<SlotDto>> GetAvailableSlotsAsync(string doctorId, DateTime date);  
    }
}
