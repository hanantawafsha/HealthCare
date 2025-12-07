using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.Data;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Services.Classes
{
    public class AppointmentService : GenericService<AppointmentRequestDto, AppointmentResponseDto, Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorScheduleService _doctorScheduleService;
        private readonly ApplicationDbContext _dbContext;



        public AppointmentService(IAppointmentRepository appointmentRepository,
            IDoctorScheduleService doctorScheduleService,
            ApplicationDbContext dbContext) : base(appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorScheduleService = doctorScheduleService;
            _dbContext = dbContext;
        }

        public async Task<AppointmentResponseDto> CreateAppointmentAsync(string patientId, string doctorId, AppointmentRequestDto request)
        {
            //check if the doctor is available 
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            List<SlotDto> availableSlots = await _doctorScheduleService.GetAvailableSlotsAsync(doctorId, request.StartTime);
            // if start time and end time is available 
            if (availableSlots == null)
            {
                throw new Exception("there is no available slot; you can't add a new appointment");
            }
            //fluent validation check this condition 
            if (request.StartTime >= request.EndTime)
            {
                throw new Exception("the end time should be greater than the start time");
            }
            var selectedSlot = availableSlots.FirstOrDefault(s => s.Start == request.StartTime.TimeOfDay && s.End == request.EndTime.TimeOfDay);
            if (selectedSlot == null)
            {
                throw new Exception("the selected slot is not available, please select another slot");
            }

            var appointment = request.Adapt<Appointment>();
            appointment.DoctorId = doctorId;
            appointment.PatientId = patientId;
            appointment.Status = AppointmentStatus.Booked;

            await _appointmentRepository.AddAsync(appointment);

            await transaction.CommitAsync();

            return appointment.Adapt<AppointmentResponseDto>();
        }

        public async Task<int> UpdateAppointmentAsyn(int id, AppointmentRequestDto request)
        {
            var appointment = await _appointmentRepository.GetByIdAsyn(id);
            var doctorId = appointment.DoctorId;
            if (appointment == null)
            {
                return 0;
            }
            if (request.StartTime >= request.EndTime)
            {
                return 0;
            }
            appointment.DoctorId= doctorId;
            appointment.StartTime = request.StartTime;
            appointment.EndTime = request.EndTime;
            //appointment.Reason = request.Reason;
            return await _appointmentRepository.UpdateAsync(appointment);
        }

        public async Task<AppointmentResponseDto> UpdateStatusAsync(int id, string status, bool isAdmin = false, string? patientId = null)
        {

            Appointment? appointment;

            if (isAdmin)
            {
                appointment = await _appointmentRepository.GetByIdAsyn(id);
            }
            else
            {
                appointment = await _dbContext.Appointments.FirstOrDefaultAsync(a => a.Id == id && a.PatientId == patientId);
            }

            if (appointment == null)
            {
                throw new ArgumentException($"Appoitnemt with ID {id} doesn't exist or not associated the person");
            }
            if (!Enum.TryParse<AppointmentStatus>(status, true, out var statusEnum))
            {
                throw new ArgumentException($"invalid status value: {status}. Allowed values are: {string.Join(",", Enum.GetNames(typeof(AppointmentStatus)))}");
            }
            appointment.Status = statusEnum;
            await _appointmentRepository.UpdateAsync(appointment);
            return appointment.Adapt<AppointmentResponseDto>();
        }
        public async Task<List<AppointmentDTO>> GetAllwithPatientInfo()
        {
            var result = await _appointmentRepository.GetAllwithPatientInfo();
            return result.Adapt<List<AppointmentDTO>>();    

        }
        public async Task<int> DeleteAppoitnemt(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsyn(id);
            if (appointment == null)
            {
                throw new ArgumentException("the entered id is wrong");
            }
            return await _appointmentRepository.DeleteAsync(appointment);

        }
    }
}
