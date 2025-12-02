using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Repositories.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {

        Task<List<Appointment>> GetAppointmentsByDoctorAsync(string doctorId);
        Task<List<Appointment>> GetAppointmentsByPatientAsync(string patientId);
        //Task<bool> IsDoctorAvailableAsync(string doctorId, DateTime startTime, DateTime endTime);
        //Task<AppointmentResponseDto> CreateAppointmentAsync(string doctorId, string patientId, AppointmentRequestDto request);
    }
}
