using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MessangerFirst.Core.Model;
using MessangerFirst.Core.Repository;
using MessangerFirst.Core.Service;

namespace MessangerFirst.Service
{
    public class CrudService<T> : ICrudService<T> where T : Entity, new()
    {
        protected IRepo<T> Repo;

        public CrudService(IRepo<T> repo)
        {
            Repo = repo;
        }

        public virtual Guid Create(T item)
        {
            var newItem = Repo.Insert(item);
            Repo.Save();
            return newItem.Id;
        }

        public void Save()
        {
            Repo.Save();
        }

        public virtual void Delete(Guid id)
        {
            Repo.Delete(Repo.Get(id));
            Repo.Save();
        }

        public T Get(Guid id)
        {
            return Repo.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Repo.GetAll();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> func)
        {
            return Repo.Where(func);
        }

        public void Update(T item)
        {
            Repo.Update(item);
            Repo.Save();
        }
    }
}
