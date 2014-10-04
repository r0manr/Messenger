using System;
using System.Linq;
using MessangerFirst.Core.Model;

namespace MessangerFirst.Core.Service
{
    public interface IMessageService : ICrudService<Message>
    {
        IQueryable<Message> GetMessages(Guid user);
        void DeleteMessage(Guid messageId, Guid userId);
    }
}
