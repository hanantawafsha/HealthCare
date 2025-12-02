using HealthCare.BLL.Repositories.Classes;
using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Responses;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Services.Classes
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;
        private readonly IDoctorWorkingHoursRepository _doctorWorkingHoursRepository;

        public DoctorScheduleService(IDoctorScheduleRepository doctorScheduleRepository,
            IDoctorWorkingHoursRepository doctorWorkingHoursRepository)
        {
            _doctorScheduleRepository = doctorScheduleRepository;
            _doctorWorkingHoursRepository = doctorWorkingHoursRepository;
        }
        public async Task<bool> HasWorkingHoursAsync(string doctorId, DayOfWeekEnum weekday)
        {
            var existingWorkingHours = await _doctorWorkingHoursRepository.GetWorkingHoursByDoctorAndDayAsync(doctorId, weekday);
            return existingWorkingHours.Any();
        }
        //for dropdown list - slot - frontend
        public async Task<List<SlotDto>> GetAvailableSlotsAsync(string doctorId, DateTime date)
        {
            var dayOfWeek = (DayOfWeekEnum)date.DayOfWeek;
            //get doctor
            var doctor = await _doctorScheduleRepository.GetDoctorAsync(doctorId);
            if (doctor is null)
                return new List<SlotDto>();

            // Get working hours
            var workingHoursList = await _doctorScheduleRepository.GetWorkingHoursAsync(doctorId, dayOfWeek);
            if (!workingHoursList.Any())
                return new List<SlotDto>();

            // Generate all slots
            var slotLength = TimeSpan.FromMinutes((long)doctor.SlotMinutes);
            var slots = new List<SlotDto>();

            foreach (var wh in workingHoursList)
            {
                var start = wh.StartTime;
                var end = wh.EndTime;

                while (start + slotLength <= end)
                {
                    slots.Add(new SlotDto
                    {
                        Start = start,
                        End = start + slotLength,
                        IsAvailable = true
                    });

                    start += slotLength;
                }
            }
            // Get doctor appointments that day
            var appointments = await _doctorScheduleRepository.GetDoctorAppointmentsAsync(doctorId, date);

            // Mark unavailable slots
            foreach (var slot in slots)
            {
                var slotStart = date.Date + slot.Start;
                var slotEnd = date.Date + slot.End;

                if (appointments.Any(a =>
                    slotStart < a.EndTime &&
                    slotEnd > a.StartTime))
                {
                    slot.IsAvailable = false;
                }
            }
            return slots.Where(s => s.IsAvailable).ToList();
        }
    }
}
