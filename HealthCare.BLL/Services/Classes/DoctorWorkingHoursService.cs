using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Services.Classes
{
    public class DoctorWorkingHoursService: GenericService<DoctorWorkingHoursRequestDTO,DoctorWorkingHoursResponseDTO,DoctorWorkingHours> ,IDoctorWorkingHoursService
    {
        private readonly IDoctorWorkingHoursRepository _doctorWorkingHoursRepository;

        public DoctorWorkingHoursService(IDoctorWorkingHoursRepository doctorWorkingHoursRepository):base(doctorWorkingHoursRepository)
        {
            _doctorWorkingHoursRepository = doctorWorkingHoursRepository;
        }

        public async Task<List<DoctorWorkingHoursResponseDTO>> GetDoctorWorkingSlotsAsync(string doctorId)
        {
            var slots = await  _doctorWorkingHoursRepository.GetDoctorWorkingSlotsAsync(doctorId);
            return slots;
        }

    }
}
