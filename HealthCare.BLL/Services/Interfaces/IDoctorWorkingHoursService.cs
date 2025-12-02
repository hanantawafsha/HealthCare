using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Services.Interfaces
{
    public interface IDoctorWorkingHoursService
    {
        Task<int> AddWorkingHoursAsync(string doctorId, DoctorWorkingHoursRequestDTO request);
        Task<IEnumerable<DoctorWorkingHours>> GetWorkingHoursAsync(string doctorId);
        Task<int> UpdateWorkingHoursAsync(int id, DoctorWorkingHoursRequestDTO request);
    }
}
