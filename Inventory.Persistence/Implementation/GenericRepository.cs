using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Common;
using Inventory.Domain.Common.Interfaces;
using Inventory.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Persistence.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<T> Entities => _db.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            return entity;
        }


        public async Task<T> UpdateAsync(T t, object key)
        {
            if (t == null)
                return null;
            T exist = await _db.Set<T>().FindAsync(key);
            if (exist != null)
            {
                _db.Entry(exist).CurrentValues.SetValues(t);
                //await _db.SaveChangesAsync();
            }
            return exist;
            //return Task.CompletedTask;
        }


        //public Task UpdateAsync(T entity)
        //{
        //    T exist = _db.Set<T>().FindAsync(entity.Id);
        //    //_db.Entry(exist).Update(product);

        //    _db.Entry(exist).CurrentValues.SetValues(entity);
        //    return Task.CompletedTask;
        //}

        //public Task UpdateAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}
        public Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db
                .Set<T>()
                .ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate);
        }
    }
}
