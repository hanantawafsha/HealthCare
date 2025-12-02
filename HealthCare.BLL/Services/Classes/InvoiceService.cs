using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.Models;
using Mapster;

namespace HealthCare.BLL.Services.Classes
{
    public class InvoiceService : GenericService<InvoiceRequestDTO, InvoiceReponseDTO, Invoice>, IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IVisitRepository _visitRepository;

        public InvoiceService(IGenericRepository<Invoice> genericRepository,
            IInvoiceRepository invoiceRepository,
            IVisitRepository visitRepository) : base(genericRepository)
        {
            _invoiceRepository = invoiceRepository;
            _visitRepository = visitRepository;
        }


        public async Task<InvoiceReponseDTO?> CreateInvoiceAsync(int visitId, InvoiceRequestDTO request)
        {
            var visit = await _visitRepository.GetByIdAsyn(visitId);
            if (visit == null)
                return null;
            var invoice = request.Adapt<Invoice>();
            invoice.VisitId = visitId;
            invoice.TotalAmount = CalculateTotalAmount(visit); 
            invoice.Visit = visit;
            var result = await _invoiceRepository.AddAsync(invoice);
            return result.Adapt<InvoiceReponseDTO>();
        }


        private decimal CalculateTotalAmount(Visit visit)
        {
            decimal treatmentsCost = visit.Treatments?.Sum(t => t.Cost) ?? 0;
            return treatmentsCost;
        }

        public async Task<InvoiceReponseDTO?> GetInvoiceByVisitIdAsync(int visitId)
        {
            var visit = await _visitRepository.GetByIdAsyn(visitId);
            if(visit == null)
            {
                return null;
            }
            var invoice =  await _invoiceRepository.GetInvoiceByVisitIdAsync(visitId);
            if (invoice == null) return null;
            return invoice.Adapt<InvoiceReponseDTO>();

        }
    }
}
