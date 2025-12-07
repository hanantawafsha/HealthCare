using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.DAL.Data;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static HealthCare.DAL.Enums.Enum;


namespace HealthCare.BLL.Repositories.Classes
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<Appointment>> GetAppointmentsByDoctorAsync(string doctorId)
        {

            return await _context.Appointments
                        .Where(a => a.DoctorId == doctorId)
                        .Include(a => a.Doctor)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByPatientAsync(string patientId)
        {
            return await _context.Appointments
                .Where(a => a.PatientId == patientId)
                        .Include(a => a.Patient)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<List<Appointment>> GetAllwithPatientInfo()
        {
            return  await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }
    }
}
