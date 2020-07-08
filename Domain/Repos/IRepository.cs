using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        Task<T> GetAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(int id);
        Task DeleteAsync(int id);
        bool SaveAll();
        Task<bool> SaveAllAsync();
    }
}