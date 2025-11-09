using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
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
        public TreatmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
