using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MessangerFirst.Core.Model;
using MessangerFirst.Core.Repository;

namespace MessangerFirst.Data
{
    /// <summary>
    /// Реализация шаблона репозиторий
    /// </summary>
    public class Repo<T> : IRepo<T> where T : Entity, new()
    {
        protected readonly DbContext DbContext;

        public Repo(IDbContextFactory f)
        {
            DbContext = f.GetContext();
        }
        public T Get(Guid id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public T Insert(T o)
        {
            DbContext.Set<T>().Add(o);
            return o;
        }

        public void Update(T o)
        {
            DbContext.Set<T>().Attach(o);
            DbContext.Entry(o).State = EntityState.Modified;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public virtual void Delete(T o)
        {
            DbContext.Set<T>().Remove(o);
        }
    }
}
