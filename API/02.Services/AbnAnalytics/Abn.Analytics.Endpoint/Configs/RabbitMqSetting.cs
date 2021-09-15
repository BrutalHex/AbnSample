using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abn.Analytics.Endpoint.Configs
{
    public class RabbitMqSetting
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
