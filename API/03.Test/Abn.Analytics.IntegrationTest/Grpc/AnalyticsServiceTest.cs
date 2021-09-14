using AutoMapper;
using Abn.Analytics.Domain;
using Abn.Analytics.IntegrationTest.Artifacts;
using Parser.IntegrationTest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Abn.Analytics.Endpoint.Controller.Dto;

namespace Parser.IntegrationTest.Grpc
{
    public class AnalyticsService : BaseIntegrationTest
    {
        public AnalyticsService(
        TestWebApplicationFactory<Abn.Analytics.Endpoint.Startup> factory) : base(factory)
        {

        }

        [Theory(DisplayName = "StartCalculation_information_store_grpc")]
        [MemberData(nameof(SampleData.Get), MemberType = typeof(SampleData))]
        public async Task StartCalculation_Valid_information_store(DataInput sampleData)
        {

            var transferClient = new Abn.Analytics.Endpoint.Grpc.AnalyticsInformation.AnalyticsInformationClient(GrpcChannel);
            var respons = await transferClient.StartCalculationAsync(new Abn.Analytics.Endpoint.Grpc.DataInput { Name=sampleData.Name,Email=sampleData.Email });

            Assert.Equal(respons.Name, sampleData.Name);
            Assert.Equal(respons.Email, sampleData.Email);
        }


    }
}
