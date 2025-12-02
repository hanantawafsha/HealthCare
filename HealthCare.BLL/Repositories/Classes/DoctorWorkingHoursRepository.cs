using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<DoctorWorkingHours>> GetWorkingHoursByDoctorAndDayAsync(string doctorId, DayOfWeekEnum day)
        {
            return await _context.DoctorWorkingHours
                .AsNoTracking()
                .Where(w => w.DoctorId == doctorId && w.Weekday == day)
                .ToListAsync();
        }

        public async Task<IEnumerable<DoctorWorkingHours>> GetWorkingHoursByDoctorAsync(string doctorId)
        {
            return await _context.DoctorWorkingHours
                .AsNoTracking()
                .Where(w => w.DoctorId == doctorId)
                .ToListAsync();
        }

        
    }
}
