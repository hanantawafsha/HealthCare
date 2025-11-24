using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Services.Classes
{
    public class InvoiceService : GenericService<InvoiceRequestDTO, InvoiceReponseDTO, Invoice>, IInvoiceService
    {
        public InvoiceService(IGenericRepository<Invoice> genericRepository) : base(genericRepository)
        {
        }
    }
}
