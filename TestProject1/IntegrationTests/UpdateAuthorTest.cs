using RestSharp;
using Xunit;

namespace TestProject1.IntegrationTests
{
    public class AuthorEndpoint
    {
        [Fact]
        public async Task UpdateAuthorTest()
        {
            var client = new RestClient("https://localhost:5001");

            var createRequest = new RestRequest("api/Author/CreateAuthor", Method.POST);
            createRequest.AddJsonBody(new { Name = "Old Author" });
            var createResponse = await client.ExecuteAsync(createRequest);
            var createdAuthor = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(createResponse.Content);
            var authorId = createdAuthor.Id.ToString();

            var updateRequest = new RestRequest($"api/Author/{authorId}", Method.PUT);
            updateRequest.AddJsonBody(new { Name = "Updated Author" });
            var updateResponse = await client.ExecuteAsync(updateRequest);

            Assert.True(updateResponse.IsSuccessful);

            var getRequest = new RestRequest($"api/Author/{authorId}", Method.GET);
            var getResponse = await client.ExecuteAsync(getRequest);

            Assert.True(getResponse.IsSuccessful);
            var retrievedAuthor = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(getResponse.Content);
            Assert.Equal("Updated Author", retrievedAuthor.Name.ToString());
        }
    }
}
