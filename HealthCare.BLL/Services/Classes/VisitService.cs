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
    public class VisitService : GenericService<VisitRequestDTO, VisitReposneDTO, Visit>, IVisitService
    {
        public VisitService(IGenericRepository<Visit> genericRepository) : base(genericRepository)
        {
        }
    }
}
