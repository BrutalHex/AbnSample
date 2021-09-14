using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Framework.Core.Ef
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> SaveChangesAsync();
    }
}
