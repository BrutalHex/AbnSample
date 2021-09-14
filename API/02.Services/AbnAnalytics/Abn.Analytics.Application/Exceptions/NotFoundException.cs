using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Application.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(Guid id) : base($"the id {id.ToString()} does not exist in Db.")
        {

        }
    }
}
