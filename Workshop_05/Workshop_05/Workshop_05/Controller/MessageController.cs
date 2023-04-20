using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using Workshop_05.Model;
using Workshop_05.Services;

namespace Workshop_05.MessageController
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {               
        IHubContext<SignalRHub> hub;
        List<Message> messages;
        protected List<ClientCallback> _callbacks = new List<ClientCallback>();
        public MessageController(IHubContext<SignalRHub> hub/*, List<Message> messages*/)
        {                  
            this.messages = new List<Message>();
            this.hub = hub;
        }
        [HttpGet]
        public List<Message> ReadAll()
        {
            return messages;            
        }

        [Route("/[controller]/[action]")]
        [HttpPost]
        public void SendMessage(Message message)
        {
            this.messages.Add(message);            
            this.hub.Clients.All.SendAsync("MessageWritten", message);
        }
        [Route("/[controller]/[action]")]
        [HttpPut]
        public void RegisterCallback(ClientCallback callback)
        {
            _callbacks.Add(callback);
        }
        [Route("/[controller]/[action]")]
        [HttpPut]
        public void UnregisterCallback(ClientCallback callback)
        {
            _callbacks.Remove(callback);
        }
    }   
}
