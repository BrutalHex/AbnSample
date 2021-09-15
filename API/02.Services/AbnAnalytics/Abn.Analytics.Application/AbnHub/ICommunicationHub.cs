using Abn.Analytics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Application.AbnHub
{
    public interface  ICommunicationHub
    {
        Task SendMessage(string connectionId, StatusObject info );
    }
}
