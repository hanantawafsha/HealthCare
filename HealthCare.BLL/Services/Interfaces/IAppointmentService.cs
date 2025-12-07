using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Services.Interfaces
{
    public interface IAppointmentService : IGenericService<AppointmentRequestDto, AppointmentResponseDto, Appointment>
    {
        Task<AppointmentResponseDto> CreateAppointmentAsync(string patientId, string doctorId, AppointmentRequestDto request);
        Task<int> UpdateAppointmentAsyn(int id, AppointmentRequestDto request);
      //  Task<int> UpdateStatusAppointmentAsyn(int id, AppointmentStatus status);
        Task<AppointmentResponseDto> UpdateStatusAsync(int id, string status, bool isAdmin = false, string? patientId=null);
        Task<List<AppointmentDTO>> GetAllwithPatientInfo();
        Task<int> DeleteAppoitnemt(int id);
    }

}
