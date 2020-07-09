using Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Delete(int id)
        {
            T entity = _entities.Find(id);

            if (entity != null)
                _entities.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await _entities.FindAsync(id);

            if (entity != null)
                _entities.Remove(entity);
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public IEnumerable<T> List()
        {
            return _entities.ToList();
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _entities.ToListAsync();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public Task UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}