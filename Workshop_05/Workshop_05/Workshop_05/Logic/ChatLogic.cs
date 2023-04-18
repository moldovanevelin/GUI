using System.Collections.Generic;
using Workshop_05.Models;

namespace Workshop_05.Logic
{
    public class ChatLogic : IChatLogic
    {
        private List<Message> _messages = new List<Message>();
        private List<IClientCallback> _callbacks = new List<IClientCallback>();

        public void SendMessage(Message message)
        {            
            _messages.Add(message);
            ;
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
