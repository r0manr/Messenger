using System;
using System.Linq;
using MessangerFirst.Core.Model;
using MessangerFirst.Core.Repository;
using MessangerFirst.Core.Service;

namespace MessangerFirst.Service
{
    public class MessageService : CrudService<Message>, IMessageService
    {
        public MessageService(IRepo<Message> repo)
            : base(repo)
        {
        }

        public IQueryable<Message> GetMessages(Guid userId)
        {
            var messages =
                Repo.Where(
                    x =>
                        (x.SenderId == userId && x.SenderDeleted == false) ||
                        (x.RecieverId == userId && x.RecieverDeleted == false));
            return messages;
        }

        public void DeleteMessage(Guid messId, Guid userId)
        {
            var message = Repo.Get(messId);
            if (message.SenderId == userId) message.SenderDeleted = true;
            if (message.RecieverId == userId) message.RecieverDeleted = true;
            Repo.Save();
        }
    }
}
