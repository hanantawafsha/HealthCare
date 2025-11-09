using HealthCare.DAL.Models;
namespace HealthCare.BLL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(bool withTracking = false);
        Task<T?> GetById(int id);
        Task<int> AddAsync(T entity);
        Task<int> Update(T entity);
        Task<int> DeleteAsync(T entity);
    }
}