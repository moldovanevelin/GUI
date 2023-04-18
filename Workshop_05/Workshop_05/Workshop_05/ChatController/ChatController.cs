using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using Workshop_05.Logic;
using Workshop_05.Models;
using Workshop_05.Services;

namespace Workshop_05.ChatController
{
    [Route("[controller]")]
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
        public List<Message> ReadAll()
        {
            return logic.GetMessages();
            
        }

        [HttpPost]
        public void SendMessage([FromBody] Message message)
        {
            logic.SendMessage(message);
            this.hub.Clients.All.SendAsync("MessageWritten", message);
        }
        
        public void RegisterCallback()
        {
            var callback = new ClientCallback();
            logic.RegisterCallback(callback);           
        }

        public void UnregisterCallback()
        {
            var callback = new ClientCallback();
            logic.UnregisterCallback(callback);            
        }
    }   
}
