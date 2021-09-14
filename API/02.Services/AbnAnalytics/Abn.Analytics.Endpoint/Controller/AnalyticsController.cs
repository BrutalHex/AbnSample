
using Abn.Analytics.ApplicationContract;
using Abn.Analytics.Domain;
using Abn.Analytics.Endpoint.Controller.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Abn.Analytics.Endpoint.Controller
{
    [Route("api/[controller]/[action]/{key?}")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
       private readonly  IDataCalculatorService _dataCalculatorctorService;
        private readonly IMapper _mapper;
        public AnalyticsController(IDataCalculatorService dataExtractorService,IMapper mapper)
        {
            _dataCalculatorctorService = dataExtractorService;
            _mapper = mapper;
        }


        /// <summary>
        /// extracts information for received data
        /// </summary>
        /// <param name="DataInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<StatusObject> StartCalculation(DataInput model)
        {
            var result =await _dataCalculatorctorService.StartCalculation(_mapper.Map<StatusObject>(model));
            return result;
        }


        [HttpGet]
        public async Task<StatusObject> GetStatus(Guid key)
        {
            // somewhere between 20 seconds and 1 minute.
            var result = await _dataCalculatorctorService.GetStatus(key);
            return result;
        }

    }
}
