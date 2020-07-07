using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private DbSet<T> _entities;

        public Repository(DataContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async void Delete(int id)
        {
            T entity = await _entities.FindAsync(id);

            if (entity != null)
                _entities.Remove(entity);
        }

        public async Task<T> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}