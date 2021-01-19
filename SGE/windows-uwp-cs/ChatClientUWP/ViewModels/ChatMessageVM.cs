using ChatClientUWP.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace ChatClientUWP.ViewModels
{
    public class ChatMessageVM
    {

        public HubConnection conn { get; set; }
        public IHubProxy proxy { get; set; }
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();

        public void SignalR()
        {
            conn = new HubConnection("http://localhost:51927/");
            proxy = conn.CreateHubProxy("ChatHub");
            conn.Start();

            //Cuando el servidor envíe un evento llamado broadcastMessage hacia el cliente, este responde con su metodo OnMessage
            //que consiste en añadir al viewmodel el mensaje recibido por el servidor
            proxy.On<ChatMessage>("broadcastMessage", OnMessage);

        }
        public void Broadcast(ChatMessage msg)
        {
            proxy.Invoke("Send", msg);
        }
        private async void OnMessage(ChatMessage msg)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                //Cuando 
                this.Messages.Add(msg);
            });
        }

    }


}

