using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Services.Classes
{
    public class TreatmentService : GenericService<TreatmentRequestDTO, TreatmentResponseDTO, Treatment>, ITreatmentSerivce
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IVisitRepository _visitRepository;

        public TreatmentService(IGenericRepository<Treatment> genericRepository,
            ITreatmentRepository treatmentRepository,
            IVisitRepository visitRepository) : base(genericRepository)
        {
            _treatmentRepository = treatmentRepository;
            _visitRepository = visitRepository;
        }

        public async Task<int> AddTreatmentAsync(int visitId, TreatmentRequestDTO request)
        {
            var visit = await _visitRepository.GetByIdAsyn(visitId);
            if (visit == null)
            {
                return 0;
            }
            var treatment = request.Adapt<Treatment>();
            treatment.VisitId = visitId;

            return await _treatmentRepository.AddAsync(treatment);
        }
    }
}
