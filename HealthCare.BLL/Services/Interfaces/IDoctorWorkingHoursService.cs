using HealthCare.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Services.Interfaces
{
    public interface IDoctorWorkingHoursService
    {
        Task<List<DoctorWorkingHoursResponseDTO>> GetDoctorWorkingSlotsAsync(string doctorId);
    }
}
