using HealthCare.BLL.Repositories.Classes;
using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Classes;
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
    public class VisitService : GenericService<VisitRequestDTO, VisitReposneDTO, Visit>, IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public VisitService(IGenericRepository<Visit> genericRepository, 
            IVisitRepository visitRepository,
            ITreatmentRepository treatmentRepository,
            IAppointmentRepository appointmentRepository) : base(genericRepository)
        {
            _visitRepository = visitRepository;
            _treatmentRepository = treatmentRepository;
            _appointmentRepository = appointmentRepository;
        }
        public async Task<VisitReposneDTO?> CreateVisitAsync(int appointmentId,VisitRequestDTO request)
        {
            var appointment = await _appointmentRepository.GetByIdAsyn(appointmentId);
            if (appointment == null)
            {
                return null;
            }

            var visit = request.Adapt<Visit>();
            visit.AppointmentId = appointmentId;
            var result =await _visitRepository.AddAsync(visit);
            var visitDto = result.Adapt<VisitReposneDTO>();
            return visitDto;
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

