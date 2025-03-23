using Newtonsoft.Json;
using RestSharp;
using Xunit;

namespace TestProject1.IntegrationTests
{
    public class IntegrationListAuthorTest
    {
        [Fact]
        public async Task ListAuthorIntegrationTest()
        {
            var client = new RestClient("https://localhost:7054");

            var listRequest = new RestRequest("api/Author/ListAuthors", Method.Get);
            var listResponse = await client.ExecuteAsync(listRequest);

            Assert.True(listResponse.StatusCode == System.Net.HttpStatusCode.OK, "Falha ao listar os autores.");

            var responseContent = JsonConvert.DeserializeObject<dynamic>(listResponse.Content);

            Assert.NotNull(responseContent.data);
            Assert.True(responseContent.data.Count > 0, "Nenhum autor encontrado.");
        }
    }
}
