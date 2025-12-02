using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.DAL.Data;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Repositories.Classes
{
    public class TreatmentRepository : GenericRepository<Treatment>, ITreatmentRepository
    {
        private readonly ApplicationDbContext _context;

        public TreatmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

       
    }
}
