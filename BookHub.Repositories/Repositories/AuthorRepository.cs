using BooksHub.Data.Models;
using BooksHub.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksHub.Repositories.Repositories
{
    public class AuthorRepository : Repository<Author> , IAuthorRepository
    {
        public AuthorRepository(BooksHubContext Context) : base(Context) { }
       
    }
}
