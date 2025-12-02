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
    public interface IVisitService : IGenericService<VisitRequestDTO, VisitReposneDTO, Visit>
    {
        Task<int> AddTreatmentAsync(int visitId, TreatmentRequestDTO request);
        Task<VisitReposneDTO?> CreateVisitAsync(int appointmentId, VisitRequestDTO request);

    }
}
