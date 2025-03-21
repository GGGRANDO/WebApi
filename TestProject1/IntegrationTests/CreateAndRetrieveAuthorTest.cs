using RestSharp;
using Xunit;

namespace TestProject1.IntegrationTests
{
    public class AuthorEndpoint
    {
        [Fact]
        public async Task CreateAndRetrieveAuthorTest()
        {
            var client = new RestClient("https://localhost:5001");

            var createRequest = new RestRequest("api/Author/CreateAuthor", Method.POST);
            createRequest.AddJsonBody(new { Name = "New Author" });
            var createResponse = await client.ExecuteAsync(createRequest);

            Assert.True(createResponse.IsSuccessful);
            var createdAuthor = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(createResponse.Content);
            Assert.NotNull(createdAuthor);
            Assert.Equal("New Author", createdAuthor.Name.ToString());

            var getRequest = new RestRequest($"api/Author/{createdAuthor.Id}", Method.GET);
            var getResponse = await client.ExecuteAsync(getRequest);

            Assert.True(getResponse.IsSuccessful);
            var retrievedAuthor = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(getResponse.Content);
            Assert.NotNull(retrievedAuthor);
            Assert.Equal("New Author", retrievedAuthor.Name.ToString());
        }
    }
}
