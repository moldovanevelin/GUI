using System;

namespace Workshop_05.Model
{
    public class Message
    {
        public string Sender { get { return "Me: "; } }
        public string Text { get; set; }
        public DateTime Date { get { return DateTime.Now; } }
        public Message()
        {
            
        }
    }
}
