using BooksHub.Data.Models;
using BooksHub.Repositories;
using BooksHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BooksHub.Models;

namespace BooksHub.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceHelper serviceHelper; 

        public BookService(IUnitOfWork unitOfWork, IServiceHelper serviceHelper)
        {
            this.unitOfWork = unitOfWork;
            this.serviceHelper = serviceHelper; 
        }

        public async Task<ServiceResponse<string>> DeleteBook(int id)
        {
            var bookResponse = serviceHelper.InitializeSrvResponse<string>();
            try
            {
                unitOfWork.Books.Remove(id); 
                await unitOfWork.CommitAsync(); 
                bookResponse = serviceHelper.SetSuccessResponse(ServerMessages.SuccessDeleteMessage, bookResponse);
            }
            catch (Exception ex)
            {
                bookResponse = serviceHelper.SetFailureResponse(ex, bookResponse, ServerMessages.FailureDeleteMessage);
            }

            return bookResponse;
        }

        public async Task<ServiceResponse<List<Book>>> GetAllBooks()
        {
            var bookListResponse = serviceHelper.InitializeSrvResponse<List<Book>>();
            try
            {
                List<Book> bookList =  await unitOfWork.Books.GetAllBooks();
                bookListResponse = serviceHelper.SetSuccessResponse(bookList, bookListResponse);
            }
            catch (Exception ex)
            {
                bookListResponse = serviceHelper.SetFailureResponse(ex, bookListResponse , null);
            }
           

            return bookListResponse; 
        }

        public async Task<ServiceResponse<Book>> GetBookById(int id)
        {
            var bookResponse = serviceHelper.InitializeSrvResponse<Book>();
            try
            {
                Book book = await unitOfWork.Books.GetById(id);
                bookResponse = serviceHelper.SetSuccessResponse(book, bookResponse);
            }
            catch (Exception ex)
            {
                bookResponse = serviceHelper.SetFailureResponse(ex, bookResponse, null);
            }


            return bookResponse;
        }

        public async Task<ServiceResponse<string>> SaveBook(Book book)
        {
            var bookResponse = serviceHelper.InitializeSrvResponse<string>();
            try
            {
                await unitOfWork.Books.Add(book);
                await unitOfWork.CommitAsync(); 
                bookResponse = serviceHelper.SetSuccessResponse(ServerMessages.SuccessSaveMessage, bookResponse);
            }
            catch (Exception ex)
            {
                bookResponse = serviceHelper.SetFailureResponse(ex, bookResponse, ServerMessages.FailureSaveMessage);
            }

            return bookResponse;
        }

        public async Task<ServiceResponse<string>> UpdateBook(Book book)
        {
            var bookResponse = serviceHelper.InitializeSrvResponse<string>();
            try
            {
                unitOfWork.Books.Update(book);
                await unitOfWork.CommitAsync(); 
                bookResponse = serviceHelper.SetSuccessResponse(ServerMessages.SuccessUpdateMessage, bookResponse);
            }
            catch (Exception ex)
            {
                bookResponse = serviceHelper.SetFailureResponse(ex, bookResponse, ServerMessages.FailureUpdateMessage);
            }

            return bookResponse;
        }

    }
}
