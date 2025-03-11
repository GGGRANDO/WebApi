using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Author;
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

        [HttpGet("SearchAuthorForId/{idAuthor}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> SearchAuthorForId(int idAuthor)
        {
            var author = await _authorInterface.SearchAuthorForId(idAuthor);
            return Ok(author);
        }

        [HttpGet("SearchAuthorForBookId/{idBook}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> SearchAuthorForBookId(int idBook)
        {
            var author = await _authorInterface.SearchAuthorForBookId(idBook);
            return Ok(author);
        }        
        
        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> CreateAuthor(AuthorEditDto authorCreateDto)
        {
            var authors = await _authorInterface.CreateAuthor(authorCreateDto);
            return Ok(authors);
        }

    }
}
