using System;

namespace MessangerFirst.Core.Model
{
    public class History : Entity
    {
        public History()
        {
            CreateOn = DateTime.Now;
        }

        public DateTime CreateOn { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
