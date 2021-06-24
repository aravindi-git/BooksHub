using BooksHub.Data.Models;
using BooksHub.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksHub.Services.Interfaces
{
    public interface IBookService
    {
        Task<ServiceResponse<Book>> GetBookById(int id );
        Task<ServiceResponse<List<Book>>> GetAllBooks();
        Task<ServiceResponse<string>> SaveBook(Book book);
        Task<ServiceResponse<string>> UpdateBook(Book book);
        Task<ServiceResponse<string>> DeleteBook(int id);

    }
}
