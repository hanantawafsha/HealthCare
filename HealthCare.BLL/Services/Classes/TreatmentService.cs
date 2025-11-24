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
    public class TreatmentService : GenericService<TreatmentRequestDTO, TreatmentResponseDTO, Treatment>, ITreatmentSerivce
    {
        public TreatmentService(IGenericRepository<Treatment> genericRepository) : base(genericRepository)
        {
        }
    }
}
