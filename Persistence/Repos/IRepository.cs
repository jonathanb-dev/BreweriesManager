using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repos
{
    interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        Task<bool> SaveAll();
    }
}