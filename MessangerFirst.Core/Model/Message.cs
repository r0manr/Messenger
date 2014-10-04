using System;

namespace MessangerFirst.Core.Model
{
    public class Message : Entity
    {
        public Message()
        {
            CreatedOn = DateTime.Now;
        }
        public DateTime CreatedOn { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid SenderId { get; set; }
        public virtual User Sender { get; set; }
        public Guid RecieverId { get; set; }
        public virtual User Reciever { get; set; }
        //Флаги устанавливают состояние сообщения для пользователя
        public bool SenderDeleted { get; set; }
        public bool RecieverDeleted { get; set; }
        public bool RecieverViewed { get; set; }
    }
}
