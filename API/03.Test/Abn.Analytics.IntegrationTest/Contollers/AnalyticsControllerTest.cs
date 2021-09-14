using Parser.IntegrationTest.Infrastructure;
using System.Threading.Tasks;
using Xunit;
using Abn.Analytics.Domain;
using System.Net.Http;
using Abn.Analytics.Endpoint.Controller.Dto;
using Abn.Analytics.IntegrationTest.Artifacts;
using System;

namespace Parser.IntegrationTest
{
    public class AnalyticsControllerTest : BaseIntegrationTest
    {
        public AnalyticsControllerTest(
        TestWebApplicationFactory<Abn.Analytics.Endpoint.Startup> factory) : base(factory)
        {

        }

        [Theory(DisplayName = "StartCalculation_Vali_information_store_http")]
        [MemberData(nameof(SampleData.Get), MemberType = typeof(SampleData))]
        public async Task StartCalculation_Valid_information_store(DataInput sampleData)
        {
            StringContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(sampleData),
               System.Text.Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync($"http://localhost:5001/api/Analytics/StartCalculation", httpContent);
            var responseData = await response.Content.ReadAsStringAsync();
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<StatusObject>(responseData);

            Assert.NotEqual(data.Id, Guid.Empty);
            Assert.Equal(data.Name, sampleData.Name);
            Assert.Equal(data.Email, sampleData.Email);
        }

     

    }
}
