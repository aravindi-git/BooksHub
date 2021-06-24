using BooksHub.Data.Models;
using BooksHub.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BooksHub.Repositories.Repositories
{
    public class BookRepository :  Repository<Book> , IBookRepository
    {

        public BookRepository(BooksHubContext Context)
           : base(Context)
        { }

        public async Task<List<Book>> GetAllBooks()
        {
          //  return await context.Book.ToListAsync();
            return await context.Book.Include(b=> b.Author).ToListAsync();
        }
    }
}
