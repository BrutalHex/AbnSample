using AutoMapper;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Parser.IntegrationTest.Infrastructure
{

    /// <summary>
    /// provides the basic functionality for integration tests
    /// </summary>
    public class BaseIntegrationTest : IClassFixture<TestWebApplicationFactory<Abn.Analytics.Endpoint.Startup>>
    {
        public TestWebApplicationFactory<Abn.Analytics.Endpoint.Startup> Factory { get; private set; }

        private readonly HttpClient _grpHttpClient;
        /// <summary>
        /// HttpClient for communicate with gRPC and Web services
        /// </summary>
        protected HttpClient GrpcHttpClient => _grpHttpClient;

        /// <summary>
        /// the gRPC channel of the project
        /// </summary>
        protected GrpcChannel GrpcChannel { get; private set; }

        public HttpClient HttpClient { get; private set; }

        

        /// <summary>
        /// provides the basic functionality for integration tests
        /// </summary>
        /// <param name="factory"></param>
        public BaseIntegrationTest(TestWebApplicationFactory<Abn.Analytics.Endpoint.Startup> factory)
        {

            Factory = factory;
            _grpHttpClient = factory.CreateClientForGrpc();
            GrpcChannel = GrpcChannel.ForAddress("https://localhost:5000", new GrpcChannelOptions()
            {
                HttpClient = GrpcHttpClient
            });

            HttpClient = factory.CreateClient();

             


        }
        /// <summary>
        /// compares first level properties of two given objects
        /// </summary>
        /// <param name="requestToSend">first object</param>
        /// <param name="respons">second object</param>
        /// <returns></returns>
        protected bool HasDifferenceInValues(object requestToSend, object respons)
        {

            var responseProps = respons.GetType().GetProperties();
            var reqProps = requestToSend.GetType().GetProperties();

            var qeury = (from res in responseProps
                         join req in reqProps
                        on res.Name equals req.Name into all
                         from c in all.DefaultIfEmpty()
                         where c != null
                         select new
                         {
                             res.Name,
                             responseValue = c != null ? (c.GetValue(respons)?.ToString()) : null,

                             requestValue = res?.GetValue(requestToSend)?.ToString()
                         }).Where(a => a.requestValue != a.responseValue
                         ).ToList();

            if (qeury.Any())
            {
                return true;
            }


            return false;

        }
    }
}
