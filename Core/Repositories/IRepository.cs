using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories {
    public interface IRepository<T> where T : EntityBase {
        Task<IReadOnlyList<T>> GetAll();
        Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
