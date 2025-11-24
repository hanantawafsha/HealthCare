using HealthCare.DAL.DTO;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Services.Interfaces
{
    public interface IInvoiceService : IGenericService<InvoiceRequestDTO, InvoiceReponseDTO,Invoice>
    {
    }
}
