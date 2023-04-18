using System.Collections.Generic;
using Workshop_05.Models;

namespace Workshop_05.Logic
{
    public class ClientCallback : IClientCallback
    {
        public void ReceiveMessage(Message message)
        {
            var messages = new List<Message> { message };
        }

    }
}
