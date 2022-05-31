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
    public class AuthorController : ControllerBase
    {
        private AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        //Add author to the Database
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
             _authorService.AddAuthor(author);
            return Ok();
        }

        //Get Author
        [HttpGet("get-authorsbook-by-id/{id}")]
        public IActionResult GetAuthorsBookById(int id)
        {
           var res = _authorService.GetAuthorsWithBook(id);
            return Ok(res);
        }
    }
}
