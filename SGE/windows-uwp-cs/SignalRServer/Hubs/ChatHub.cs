using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZUMOAPPNAME.DataModel;
using ZUMOAPPNAME.Hubs;

namespace ZUMOAPPNAME.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(ChatMessage message)
        {
            Clients.All.broadcastMessage(message);
        }
    }

}
