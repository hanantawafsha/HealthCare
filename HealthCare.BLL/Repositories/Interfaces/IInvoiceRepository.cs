using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Repositories.Interfaces
{
    public interface IInvoiceRepository:IGenericRepository<Invoice>
    {
        Task<Invoice?> GetInvoiceByVisitIdAsync(int visitId);
    }
}
