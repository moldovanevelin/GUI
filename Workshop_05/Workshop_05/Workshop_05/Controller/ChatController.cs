using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using Workshop_05.Logic;
using Workshop_05.Models;
using Workshop_05.Services;

namespace Workshop_05.ChatController
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {        
        IChatLogic logic;
        IHubContext<SignalRHub> hub;
        public ChatController(IChatLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;            
            this.hub = hub;
        }
        [HttpGet]
        public List<Message> ReadAll()
        {
            return logic.GetMessages();            
        }

        [HttpPost]
        public void SendMessage([FromBody] Message message)
        {
            this.logic.SendMessage(message);            
            this.hub.Clients.All.SendAsync("MessageWritten", message);
        }        
        [HttpPut]
        public void RegisterCallback()
        {
            var callback = new ClientCallback();
            logic.RegisterCallback(callback);           
        }
        
        [HttpPut]
        public void UnregisterCallback()
        {
            var callback = new ClientCallback();
            logic.UnregisterCallback(callback);            
        }
    }   
}
