using Abn.Analytics.Domain;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Application.AbnHub
{
    public class CommunicationHub : Hub, ICommunicationHub
    {
        IHubContext<CommunicationHub> _hubContext;
    
        public CommunicationHub(IHubContext<CommunicationHub> hubContext  )
        {
            _hubContext = hubContext;
            
        }

        int index = 0;
        public async Task SendMessage(string connectionId, StatusObject info )
        {
            await _hubContext.Clients.Client(connectionId).SendAsync("SendMessage", info, new System.Threading.CancellationToken());

        }



      



       


    }
}
