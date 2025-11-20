using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Repositories.Interfaces
{
    public interface IAddressRepository:IGenericRepository<Address>
    {
        Task<UserDto> GetUserAddress(string UserId);
    }
}
