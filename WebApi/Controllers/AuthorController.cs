using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Authors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface _authorInterface;
        public AuthorController(IAuthorInterface authorInterface) 
        { 
            _authorInterface = authorInterface;
        }

        [HttpGet("ListAuthors")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> ListAuthors() 
        { 
            var authors = await _authorInterface.ListAuthors();
            return Ok(authors);
        }

        [HttpGet("SearchAuthor/{idAuthor}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> SearchAuthorId(int idAuthor)
        {
            var author = await _authorInterface.SearchAuthorId(idAuthor);
            return Ok(author);
        }

        [HttpGet("SearchAuthorForBookId/{idBook}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> SearchAuthorForBookId(int idBook)
        {
            var author = await _authorInterface.SearchAuthorForBookId(idBook);
            return Ok(author);
        }

    }
}
