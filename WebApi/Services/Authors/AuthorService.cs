using Azure;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Author;
using WebApi.Models;

namespace WebApi.Services.Authors
{
    public class AuthorService : IAuthorInterface
    {

        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<ResponseModel<AuthorModel>> SearchAuthorId(int idAuthor)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorBank => authorBank.Id == idAuthor);
                
                if (author == null) 
                {
                    response.Message = "No record localizated!";
                    return response;
                }

                response.Data = author;
                response.Message = "Author localizated!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<AuthorModel>> SearchAuthorForBookId(int idBook)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(bankBook => bankBook.Id == idBook);

                if (book == null)
                {
                    response.Message = "No record localizated!";
                    return response;
                }

                response.Data = book.Author;
                response.Message = "Author localizated!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> ListAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var authors = await _context.Authors.ToListAsync();
                response.Data = authors;
                response.Message = "All authors have been collected!";

                return response;

            }
            catch (Exception ex)
            { 
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<BookModel>> SearchBookId(int idBook)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(bookBank => bookBank.Id == idBook);

                if (book == null)
                {
                    response.Message = "No record localizated!";
                    return response;
                }

                response.Data = book;
                response.Message = "Book localizated!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ResponseModel<AuthorModel>> SearchAuthorForId(int idBook)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorEditDto authorCreateDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var author = new AuthorModel()
                {
                    Name = authorCreateDto.Name,
                    LastName = authorCreateDto.LastName
                };
                _context.Add(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author create with successfully";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ResponseModel<List<AuthorModel>>> EditAuthor(AuthorEditDto authorCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(AuthorEditDto authorCreateDto)
        {
            throw new NotImplementedException();
        }
    }
}
