using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Application.Exceptions
{
    public class InvalidInputException:Exception
    {
        public InvalidInputException(List<string> messages) :base(string.Join(",",messages))
        {

        }
    }
}
