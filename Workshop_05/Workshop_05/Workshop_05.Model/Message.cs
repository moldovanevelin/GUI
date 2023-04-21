using System;
using System.ComponentModel;

namespace Workshop_05.Model
{
    public class Message
    {
        public string Sender { get; set; }       
        public string Text { get; set; }
        public DateTime Date { get { return DateTime.Now; } }
        public Message()
        {
            
        }
       
    }
}
