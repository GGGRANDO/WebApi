using RestSharp;
using Newtonsoft.Json;
using Xunit;

public class IntegrationCreateAuthorTest
{
    [Fact]
    public async Task CreateAuthorIntegrationTest()
    {
        var client = new RestClient("https://localhost:7054");

        var createRequest = new RestRequest("api/Author/CreateAuthor", Method.Post);
        createRequest.AddJsonBody(new { name = "New Author", lastName = "Teste" });
        var createResponse = await client.ExecuteAsync(createRequest);

        Assert.True(createResponse.StatusCode == System.Net.HttpStatusCode.OK, "Falha ao criar o autor.");

        var responseContent = JsonConvert.DeserializeObject<dynamic>(createResponse.Content);
        Assert.True(responseContent.status == true, "O autor não foi criado com sucesso.");

    }
}
