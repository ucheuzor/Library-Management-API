using BookApi.Data.Model;
using BookApi.Data.Services;
using BookApi.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //initiallizing the book service
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }
        
        //Adding controller to save item to Database
        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        //Controller to get all books
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        //Controller to get a Book
        [HttpGet("get-book-by-Id/{bookId}")]
        public IActionResult GetBookById(int bookId) 
        {
            var singleBook = _booksService.GetABook(bookId);
            return Ok(singleBook);
        }

        //Controller to update an existing Book
        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBook(id, book);
            return Ok(updatedBook);
        }

        //Controller to delete a existing Book
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
