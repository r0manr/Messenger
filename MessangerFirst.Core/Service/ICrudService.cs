using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MessangerFirst.Core.Model;

namespace MessangerFirst.Core.Service
{
    /// <summary>
    /// Интерфейс CRUD-сервиса
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    public interface ICrudService<T> where T : Entity, new()
    {
        Guid Create(T item);
        void Save();
        void Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> func);
        void Update(T item);
    }
}
