using WebApi.Models;

namespace WebApi.Services.Authors
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> ListAuthors();
        Task<ResponseModel<AuthorModel>> SearchAuthorId(int idAuthor);
        Task<ResponseModel<AuthorModel>> SearchAuthorForId(int idBook);
        Task<ResponseModel<AuthorModel>> SearchAuthorForBookId(int idBook);
    }
}
