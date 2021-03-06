﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        Task<T> GetAsync(int id);
        IEnumerable<T> List();
        Task<IEnumerable<T>> ListAsync();
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(int id);
        Task DeleteAsync(int id);
        bool Save();
        Task<bool> SaveAsync();
    }
}