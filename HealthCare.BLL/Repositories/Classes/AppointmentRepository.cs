using HealthCare.BLL.Repositories.Interfaces;
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Repositories.Classes
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
