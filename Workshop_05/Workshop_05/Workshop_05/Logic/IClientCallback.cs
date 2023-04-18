using Workshop_05.Models;

namespace Workshop_05.Logic
{
    public interface IClientCallback
    {
        void ReceiveMessage(Message message);
    }
}