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
                        .AsNoTracking()
                        .ToListAsync();

        }

        public async Task<List<Appointment>> GetAppointmentsByPatientAsync(string patientId)
        {
            return await _context.Appointments
                        .Where(a => a.PatientId == patientId)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public Task<bool> IsDoctorAvailableAsync(string doctorId, DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }
    }
}
