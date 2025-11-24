using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.DAL.Data;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Repositories.Classes
{
    public class DoctorWorkingHoursRepository : GenericRepository<DoctorWorkingHours>, 
        IDoctorWorkingHoursRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorWorkingHoursRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<DoctorWorkingHoursResponseDTO>> GetDoctorWorkingSlotsAsync(string doctorId)
        {
            var doctor = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == doctorId);
            if (doctor is null) return new List<DoctorWorkingHoursResponseDTO>();

            var workingHours = await _context.DoctorWorkingHours
                .Include(d => d.Doctor)
                .Where(d => d.DoctorId == doctorId)
                .ToListAsync();
            if (workingHours == null) return new List<DoctorWorkingHoursResponseDTO>();

            var result = new List<DoctorWorkingHoursResponseDTO>();
            foreach (var wh in workingHours)
            {
                var dto = wh.Adapt<DoctorWorkingHoursResponseDTO>();
                dto.DoctorName = wh.Doctor.FullName;
                // generate Slots based on SlotMinutes
                var slotLength = TimeSpan.FromMinutes((long)doctor.SlotMinutes);
                var start = wh.StartTime;
                var end = wh.EndTime;
                while (start + slotLength <= end)
                {
                    dto.slotDtos.Add(new SlotDto
                    {
                        Start = start,
                        End = start + slotLength,
                        IsAvailable = true
                    });
        
        start += slotLength;
                }

                result.Add(dto);
            }

            return result;
        }
        
      
        public async Task<List<SlotDto>> GetAvailableSlotsAsync(string doctorId, DateTime date)
        {
            var doctor = await _context.Users.FirstOrDefaultAsync(u => u.Id == doctorId);
            if (doctor is null) return new List<SlotDto>();

            var dayOfWeek = (DayOfWeekEnum)date.DayOfWeek;

            var workingHours = await _context.DoctorWorkingHours
                .Where(d => d.DoctorId == doctorId && d.Weekday == dayOfWeek)
                .FirstOrDefaultAsync();

            if (workingHours == null) return new List<SlotDto>();

            var slotLength = TimeSpan.FromMinutes((long)doctor.SlotMinutes);
            var start = workingHours.StartTime;
            var end = workingHours.EndTime;

            var slots = new List<SlotDto>();

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
            //return doctor appointment based on date
            var appointments = await _context.Appointments
                .Where(a => a.DoctorId == doctorId && a.StartTime.Date == date.Date)
                .ToListAsync();

            foreach (var slot in slots)
            {
                var slotStartDateTime = date.Date + slot.Start;
                var slotEndDateTime = date.Date + slot.End;
                //check booked slots
                if (appointments.Any(a => slotStartDateTime < a.EndTime && slotEndDateTime > a.StartTime))
                {
                    slot.IsAvailable = false;
                }
            }

             return slots.Where(s => s.IsAvailable).ToList();

            //return slots;

        }

        public async Task<int> AddWorkingHoursAsync(DoctorWorkingHoursDto doctorWorkingHrs, string doctorId)
        {

            var doctorExists = await _context.Users.AnyAsync(u => u.Id == doctorId);
            if (!doctorExists) return -1;

            var exists = await _context.DoctorWorkingHours
                    .AnyAsync(d => d.DoctorId == doctorId && d.Weekday == doctorWorkingHrs.Weekday);
            if (exists) return 0;

            var workingHours = doctorWorkingHrs.Adapt<DoctorWorkingHours>();
            workingHours.DoctorId = doctorId;
            await _context.DoctorWorkingHours.AddAsync(workingHours);
            return await _context.SaveChangesAsync();

        }

    }
}
