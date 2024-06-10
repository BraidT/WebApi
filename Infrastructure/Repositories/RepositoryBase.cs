using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories {
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase {
        protected readonly ApiContext _dbContext;

        public RepositoryBase(ApiContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAll() {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>> predicate) {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> Get(int id) {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T entity) {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity) {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity) {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
