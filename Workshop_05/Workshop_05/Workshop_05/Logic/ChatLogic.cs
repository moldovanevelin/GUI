using System;
using System.Collections.Generic;
using Workshop_05.Models;

namespace Workshop_05.Logic
{
    public class ChatLogic : IChatLogic
    {
        protected List<Message> _messages=new List<Message>();
        protected List<IClientCallback> _callbacks = new List<IClientCallback>();

        public void SendMessage(string messageText)
        { 
            Message message = new Message();
            message.Text = messageText;
            message.Sender = "Sender";
            message.Date = DateTime.Now;
            _messages.Add(message);            
            foreach (var callback in _callbacks)
            {
                callback.ReceiveMessage(message);
            }
        }

        public void RegisterCallback(IClientCallback callback)
        {            
            _callbacks.Add(callback);
        }

        public void UnregisterCallback(IClientCallback callback)
        {
            _callbacks.Remove(callback);
        }

        public List<Message> GetMessages()
        {
            return _messages;
        }
    }
}
