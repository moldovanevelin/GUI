using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.AspNetCore.SignalR;
using System;
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
        public static List<Message> messages = new List<Message>();
        protected List<ClientCallback> _callbacks = new List<ClientCallback>();
        public MessageController(IHubContext<SignalRHub> hub)
        {         
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
            messages.Add(message);            
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
