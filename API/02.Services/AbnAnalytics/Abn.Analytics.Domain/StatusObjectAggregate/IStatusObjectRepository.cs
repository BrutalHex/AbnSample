using Abn.Framework.Core.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Domain.StatusObjectAggregate
{
    public interface IStatusObjectRepository:IRepository<StatusObject,Guid>
    {
    }
}
