using BooksHub.Data.Models;
using BooksHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService; 
        public BookController (IBookService bookService)
        {
            this.bookService = bookService; 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await bookService.GetBookById(id);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await bookService.GetAllBooks();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            var response = await bookService.SaveBook(book);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(Book book)
        {
            var response = await bookService.UpdateBook(book);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await bookService.DeleteBook(id);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }
    }
}
