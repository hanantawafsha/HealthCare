using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Interfaces;
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
        public async Task<TreatmentResponseDTO> UpdateTreatmentAsync (int treatmentId, TreatmentRequestDTO request)
        {
            var treatment = await _treatmentRepository.GetByIdAsyn(treatmentId);
            if (treatment == null)
            {
                throw new Exception("the selected treatment doesn't exist");
            }
            if (request == null)
            {
                throw new Exception("Please enter data");
            }
            var treatmentDTO = await _treatmentRepository.UpdateAsync(treatment);
            return treatmentDTO.Adapt<TreatmentResponseDTO>();
        }
        public async Task<int> DeleteTreatmentAsync( int treatmentId)
        {
            var treatment = await _treatmentRepository.GetByIdAsyn(treatmentId);
            if (treatment == null)
            {
                throw new Exception("the selected treatment doesn't exist");
            }
            return await _treatmentRepository.DeleteAsync(treatment);
        }
        
        public async Task<List<TreatmentResponseDTO>> GetTreatmentbyVisitIdAsync(int visitId)
        {

            var visit = await _visitRepository.GetByIdAsyn(visitId);
            if (visit == null)
            {
                return new List<TreatmentResponseDTO>();
            }

            var treatments = await _treatmentRepository.GetTreatmentsByVisitIdAsync(visitId);
            return treatments.Select(t => new TreatmentResponseDTO
            {
                Id = t.Id,
                Name = t.Name,
                Cost = t.Cost,
                Description = t.Description
            }).ToList();
        }

    }
}
