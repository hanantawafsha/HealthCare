using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Repositories.Classes
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Invoice?> GetInvoiceByVisitIdAsync(int visitId)
        {
            return await _context.Invoices
                .Include(i => i.Visit)
                .FirstOrDefaultAsync(i => i.VisitId == visitId);
        }

    }
}
