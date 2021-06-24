using System;
using System.Collections.Generic;

namespace BooksHub.Data.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Titile { get; set; }
        public int? AuthorId { get; set; }
        public string Language { get; set; }

        public virtual Author Author { get; set; }
    }
}
