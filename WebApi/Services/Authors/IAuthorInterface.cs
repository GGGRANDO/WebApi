using WebApi.Models;
using WebApi.Dto.Author;

namespace WebApi.Services.Authors
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> ListAuthors();
        Task<ResponseModel<AuthorModel>> SearchAuthorForId(int idBook);
        Task<ResponseModel<AuthorModel>> SearchAuthorForBookId(int idBook);
        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorEditDto authorCreateDto);
        Task<ResponseModel<List<AuthorModel>>> EditAuthor(AuthorEditDto authorEditDto);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor);

    }
}
