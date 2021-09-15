using Abn.Analytics.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.ApplicationContract
{
    public interface IDataCalculatorService
    {
        public Task<StatusObject> StartCalculation(StatusObject model);
        public Task<StatusObject> GetStatus(Guid id);

       public Task ProcessCalculation(StatusObject input);


    }
}
