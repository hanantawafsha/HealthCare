using HealthCare.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Services.Interfaces
{
    public interface IDoctorScheduleService
    {
        Task<List<SlotDto>> GetAvailableSlotsAsync(string doctorId, DateTime date);

    }
}
