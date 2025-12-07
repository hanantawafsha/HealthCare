using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Repositories.Interfaces
{
    public interface ITreatmentRepository:IGenericRepository<Treatment>
    {
        Task<List<Treatment>> GetTreatmentsByVisitIdAsync(int visitId);
    }
}
