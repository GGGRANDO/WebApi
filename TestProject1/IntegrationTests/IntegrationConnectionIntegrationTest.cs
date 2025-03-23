using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Data;
using Xunit;

namespace TestProject1.IntegrationTests
{
    public class IntegrationConnectionIntegrationTest
    {
        private readonly string _connectionString;

        public IntegrationConnectionIntegrationTest()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [Fact]
        public async Task TestDatabaseConnection()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(_connectionString) .Options;

            try
            {
                using (var context = new AppDbContext(options))
                {
                    await context.Database.OpenConnectionAsync();
                    Assert.True(true, "Conexão com o banco de dados bem-sucedida.");
                }
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Falha ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}
