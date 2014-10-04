using System;

namespace MessangerFirst.Core.Model
{
    /// <summary>
    /// Родительский класс сущностей
    /// </summary>
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
