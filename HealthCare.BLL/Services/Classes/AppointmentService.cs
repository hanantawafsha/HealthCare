using Azure;
using HealthCare.BLL.Repositories.Classes;
using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Services.Classes
{
    public class AppointmentService : GenericService<AppointmentRequestDto, AppointmentResponseDto, Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorScheduleService _doctorScheduleService;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorScheduleService doctorScheduleService) : base(appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorScheduleService = doctorScheduleService;
        }

        public async Task<AppointmentResponseDto> CreateAppointmentAsync(string patientId, string doctorId, AppointmentRequestDto request)
        {
            var appointment = request.Adapt<Appointment>();
            appointment.DoctorId = doctorId;
            appointment.PatientId = patientId;
            appointment.Status = AppointmentStatus.Booked;
            await _appointmentRepository.AddAsync(appointment);
            return appointment.Adapt<AppointmentResponseDto>();
        }

        public async Task<int> UpdateAppointmentAsyn(int id, AppointmentRequestDto request)
        {

            var appointment = await _appointmentRepository.GetByIdAsyn(id);
            var DoctorId = appointment.DoctorId;
            if (appointment == null)
            {
                return 0;
            }
            if (request.StartTime >= request.EndTime)
            {
                return 0;
            }
            //var availableSlot = _doctorScheduleService.GetAvailableSlotsAsync
            appointment.StartTime = request.StartTime;
            appointment.EndTime = request.EndTime;
            //appointment.EndTime = request.EndTime;
            //appointment.Reason = request.Reason;
            return await _appointmentRepository.UpdateAsync(appointment);
        }
        public async Task<int> UpdateStatusAppointmentAsyn(int id, AppointmentStatus status)
        {
            var appointment = await _appointmentRepository.GetByIdAsyn(id);
            if (appointment == null)
            {
                return 0;
            }

            appointment.Status = status;
            return await _appointmentRepository.UpdateAsync(appointment);
        }
    }

}
