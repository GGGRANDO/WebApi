using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using WebApi.Models;  // Adicionando o namespace do projeto WebApi

namespace TestProject1.UnitTests
{
    public class UnitBookConsultTest
    {
        [Fact]
        public async Task SearchBookForId()
        {
            var book = new Book
            { Id = 1, Title = "Test Book", AuthorId = 1, Author = new Author { Id = 1, Name = "Author Test" } };

            var data = new List<Book> { book }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DbContext>();
            mockContext.Setup(c => c.Set<Book>()).Returns(mockSet.Object);

            var bookRepository = new BookRepository(mockContext.Object);

            var result = await bookRepository.SearchForId(1);

            Assert.NotNull(result);
            Assert.Equal(book.Id, result.Id);
            Assert.Equal("Test Book", result.Title);
            Assert.Equal("Author Test", result.Author.Name);
        }
    }

}
