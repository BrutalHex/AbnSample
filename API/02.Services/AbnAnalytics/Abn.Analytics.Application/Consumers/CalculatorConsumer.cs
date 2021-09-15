using Abn.Analytics.ApplicationContract;
using Abn.Analytics.Domain;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Application.Consumers
{
 
    public class CalculatorConsumer : IConsumer<StatusObject>
    {
 
        private  readonly IDataCalculatorService _dataCalculatorService;
        public CalculatorConsumer(IDataCalculatorService dataCalculatorService)
        {
            _dataCalculatorService = dataCalculatorService;
        }



        public async Task Consume(ConsumeContext<StatusObject> context)
        {

            await _dataCalculatorService.ProcessCalculation(context.Message);
        }

    }

}
