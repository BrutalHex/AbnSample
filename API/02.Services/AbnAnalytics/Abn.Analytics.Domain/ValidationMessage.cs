using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Domain
{
    public class ValidationMessage
    {
        public ValidationMessage()
        {
            _messages = new List<string>();
        }

        bool _success;
        public bool Success => _success;
        public List<string> Messages => _messages.ToList();

        private List<string> _messages;

        public void Failed(string message)
        {
            _messages.Add(message);
            _success = false;
        }
        public void Failed(List<string> message)
        {
            _messages.AddRange(message);
            _success = false;
        }

        internal void SetSuccess()
        {
            _success = true;
        }
    }
}
