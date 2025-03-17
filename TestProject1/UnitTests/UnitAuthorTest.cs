using WebApi.Models;

namespace TestProject1.UnitTests
{
    public class IntegrationConnectionTest
    {
        [Fact]
        public void AuthorTest()
        {
            var author = new AuthorModel { Id = 1, Name = "John", LastName = "Tolkien" };
            Assert.Equal(1, author.Id);
            Assert.Equal("John", author.Name);
            Assert.Equal("Tolkien", author.LastName);
        }
    }
}
