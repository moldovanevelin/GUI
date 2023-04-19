using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using Workshop_05.Model;
using Workshop_05.Services;

namespace Workshop_05.ChatController
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {               
        IHubContext<SignalRHub> hub;
        List<Message> messages;
        protected List<ClientCallback> _callbacks = new List<ClientCallback>();
        public ChatController(IHubContext<SignalRHub> hub, List<Message> messages)
        {                  
            this.messages = messages;
            this.hub = hub;
        }
        [HttpGet]
        public List<Message> ReadAll()
        {
            return messages;            
        }

        [HttpPost]
        public void SendMessage(Message message)
        {
            this.messages.Add(message);            
            this.hub.Clients.All.SendAsync("MessageWritten", message);
        }        
        [HttpPut]
        public void RegisterCallback(ClientCallback callback)
        {
            _callbacks.Add(callback);
        }
        
        [HttpPut]
        public void UnregisterCallback(ClientCallback callback)
        {
            _callbacks.Remove(callback);
        }
    }   
}
