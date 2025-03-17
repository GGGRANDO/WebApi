using RestSharp;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1.IntegrationTests
{
    public class AuthorEndpoint
    {
        private Process _apiProcess;

        public AuthorEndpoint()
        {
            _apiProcess = new Process();
            _apiProcess.StartInfo = new ProcessStartInfo("dotnet", "run --project WebApi")
            {
                UseShellExecute = true,
                CreateNoWindow = true
            };
        }

        [Fact]
        public async Task TestListAuthors()
        {
            _apiProcess.Start();

            var client = new RestClient("https://localhost:7054");
            var request = new RestRequest("api/Author/ListAuthors", Method.Get);

            var success = await WaitForApiToStart(client, 30, 1000); 

            Assert.True(success, "API não respondeu a tempo");

            var response = client.Execute(request);

            Assert.True(response.IsSuccessful);
            Assert.Contains("status", response.Content);

            _apiProcess.Kill();
        }

        private async Task<bool> WaitForApiToStart(RestClient client, int maxRetries, int delayMilliseconds)
        {
            int attempts = 0;

            while (attempts < maxRetries)
            {
                try
                {
                    var request = new RestRequest("api/Author/ListAuthors", Method.Get);
                    var response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        return true;
                    }
                }
                catch
                {

                }
                attempts++;
                await Task.Delay(delayMilliseconds);
            }

            return false;
        }
    }
}
