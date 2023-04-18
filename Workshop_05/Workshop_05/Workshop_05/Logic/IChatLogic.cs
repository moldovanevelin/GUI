using System.Collections.Generic;
using Workshop_05.Models;

namespace Workshop_05.Logic
{
    public interface IChatLogic
    {
        void SendMessage(Message message);
        void RegisterCallback(IClientCallback callback);
        void UnregisterCallback(IClientCallback callback);
        List<Message> GetMessages();
    }
}