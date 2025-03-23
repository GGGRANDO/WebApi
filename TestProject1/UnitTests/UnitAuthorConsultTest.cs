using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Data;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace TestProject1.UnitTests
{
    public class AuthorConsultTest
    {
        private readonly AppDbContext _context;

        public AuthorConsultTest()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options;

            _context = new AppDbContext(options);
        }

        [Fact]
        public async Task GetAuthorByName_Should_Return_Author_If_Exists()
        {
            var author = await _context.Authors.Where(a => a.Name == "Gustavo").FirstOrDefaultAsync();

            Assert.NotNull(author);
            Assert.Equal(8, author.Id);
            Assert.Equal("Gustavo", author.Name);
        }
    }
}
