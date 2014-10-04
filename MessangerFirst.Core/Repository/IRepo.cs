using System;
using System.Linq;
using System.Linq.Expressions;

namespace MessangerFirst.Core.Repository
{
    /// <summary>
    /// Интерфейс шаблона "Репозиторий"
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IRepo<T>
    {
        T Get(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        T Insert(T o);
        void Update(T o);
        void Save();
        void Delete(T o);
    }
}
