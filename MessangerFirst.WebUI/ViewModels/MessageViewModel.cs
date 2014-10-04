using System;

namespace MessangerFirst.WebUI.ViewModels
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecieverId { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
    }
}