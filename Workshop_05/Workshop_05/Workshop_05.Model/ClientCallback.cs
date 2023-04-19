using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_05.Model
{
    public class ClientCallback
    {
        public void ReceiveMessage(Message message)
        {
            var messages = new List<Message> { message };
        }
    }
}
