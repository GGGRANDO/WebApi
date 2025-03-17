using WebApi.Models;

namespace TestProject1.UnitTests
{
    public class UnitBookTest
    {
        [Fact]
        public void BookTest()
        {
            var book = new BookModel { Id = 1, Title = "Lord of Rings", AuthorId = 1, Author = new AuthorModel { Id = 1, Name = "John", LastName = "Tolkien" } };
            Assert.Equal(1, book.Id);
            Assert.Equal("Lord of Rings", book.Title);
            Assert.Equal(1, book.AuthorId);
            Assert.Equal("John", book.Author.Name);
        }
    }
}