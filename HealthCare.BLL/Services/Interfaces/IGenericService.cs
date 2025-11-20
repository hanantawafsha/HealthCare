using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BLL.Services.Interfaces
{
    public interface IGenericService<TRequest, TResponse, TEntity> 
    {
        Task<int> AddAsync(TRequest request);
        Task<int> UpdateAsync(int id, TRequest request);
        Task<int> DeleteAsync(int id);
        Task<TResponse?> GetByIdAsync(int id);
        Task<IEnumerable<TResponse>> GetAllAsync();
    }
}