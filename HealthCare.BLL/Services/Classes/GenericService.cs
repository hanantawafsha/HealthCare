using HealthCare.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.BLL.Repositories.Interfaces;
using Mapster;

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
            var entity = request.Adapt<TEntity>();
           return await _genericRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsyn(id);
            if (entity is null) return 0;
            return await _genericRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<TResponse>> GetAllAsync()
        {
            var entity = await _genericRepository.GetAllAsync();
            return entity.Adapt<IEnumerable<TResponse>>();

        }

        public async Task<TResponse?> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsyn(id);
            return entity is null ? default : entity.Adapt<TResponse>();
        }

        public async Task<int> UpdateAsync(int id, TRequest request)
        {
            var entity = await _genericRepository.GetByIdAsyn(id);
            if (entity is null) return 0;
            var updatedEntity =  request.Adapt(entity);
            return  await _genericRepository.UpdateAsync(updatedEntity);
        }
    }
}
