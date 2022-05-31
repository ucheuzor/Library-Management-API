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
    public class PublisherController : ControllerBase
    {
        public PublisherService _publisherService;
        public PublisherController(PublisherService publisherService )
        {
            _publisherService = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
           var newPublisher = _publisherService.AddPublisher(publisher);
            return Created(nameof(AddPublisher), newPublisher);
        }

        //Creating a controller to get Publisher books and authors
        [HttpGet("get-publisher-books-by-id/{id}")]
        public IActionResult GetPublisherBooks(int id)
        {
            var res = _publisherService.GetPublisherData(id);
            return Ok(res);
        }  
        
        //Get Publisher By ID
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var res = _publisherService.GetPublisherById(id);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        //Deleting a Publisher
        [HttpDelete("delete-pubisher-by-Id")]
        public IActionResult DeletePublisherById(int id)
        {
            _publisherService.DeletePublisherById(id);
            return Ok();
        }
    }
}
