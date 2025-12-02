using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCare.DAL.Enums.Enum;

namespace HealthCare.BLL.Repositories.Classes
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(string doctorId, DateTime date)
        {
            return await _context.Appointments
                        .Where(a => a.DoctorId == doctorId && a.StartTime.Date == date.Date)
                        .ToListAsync();
        }

        public async Task<ApplicationUser> GetDoctorAsync(string doctorId)
        {
            return await _context.Users
                        .FirstOrDefaultAsync(u => u.Id == doctorId);
        }

        public async Task<List<DoctorWorkingHours>> GetWorkingHoursAsync(string doctorId, DayOfWeekEnum day)
        {
            return await _context.DoctorWorkingHours
                        .Where(d => d.DoctorId == doctorId && d.Weekday == day)
                        .ToListAsync();
        }

        //public Task<bool> HasWorkingHoursAsync(string doctorId, DayOfWeekEnum weekday)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
