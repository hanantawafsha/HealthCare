using HealthCare.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.BLL.Repositories.Interfaces;

namespace HealthCare.BLL.Services.Classes
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> _genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<int> AddAsync(TRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TResponse>> GetAllAsync(bool withTracking = false)
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(int id, TRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
