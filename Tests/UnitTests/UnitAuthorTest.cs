using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Xunit;

namespace WebApi
{
    public class NewXUnit
    {
        [Fact]
        public void AuthorTest()
        {
            var author = new AuthorModel{Id = 1, Name = "John", LastName = "Tolkien" };
            Assert.Equal(1, author.Id); 
            Assert.Equal("John", author.Name); 
            Assert.Equal("Tolkien", author.LastName); 
        }
    }
}