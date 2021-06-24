using BooksHub.Data.Models;
using BooksHub.Repositories.Interfaces;
using BooksHub.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksHub.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly BooksHubContext context;
        private AuthorRepository authorRepository;
        private BookRepository bookRepository; 
        public UnitOfWork(BooksHubContext context)
        {
            this.context =context; 
        }
        public IAuthorRepository Authors => authorRepository ?? new AuthorRepository(context);

        public IBookRepository Books => bookRepository ?? new BookRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync(); 
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
