
using Abn.Analytics.ApplicationContract;
using Grpc.Core;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abn.Analytics.Endpoint.Grpc.services
{

    /// <summary>
    /// AnalyticsService
    /// </summary>
    /// <remarks>
    /// grpc ui command:
    /// grpcui -plaintext localhost:5000
    /// </remarks>
    public class AnalyticsService :  AnalyticsInformation.AnalyticsInformationBase
    {
        private readonly IDataCalculatorService _dataCalculatorctorService;
        private readonly IMapper _mapper;
        public AnalyticsService(IDataCalculatorService dataExtractorService, IMapper mapper)
        {
            _dataCalculatorctorService = dataExtractorService;
            _mapper = mapper;
        }



        /// <summary>
        /// extracts information for received data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async override Task<Abn.Analytics.Endpoint.Grpc.StatusObject> StartCalculation(Abn.Analytics.Endpoint.Grpc.DataInput request, ServerCallContext context)
        {
            var result = await _dataCalculatorctorService.StartCalculation(_mapper.Map<Domain.StatusObject>(request));
            return _mapper.Map<Abn.Analytics.Endpoint.Grpc.StatusObject>(result);
        }

        /// <summary>
        /// returns current status of an Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async override Task<Abn.Analytics.Endpoint.Grpc.StatusObject> GetStatus(Abn.Analytics.Endpoint.Grpc.SearchInput request, ServerCallContext context)
        {
            var result = await _dataCalculatorctorService.GetStatus(Guid.Parse(request.Id));
            return _mapper.Map<Abn.Analytics.Endpoint.Grpc.StatusObject>(result);
        }

        
    }
}
