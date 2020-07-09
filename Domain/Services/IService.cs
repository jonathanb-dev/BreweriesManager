using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> ListAsync();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        Task<bool> SaveAsync();
    }
}