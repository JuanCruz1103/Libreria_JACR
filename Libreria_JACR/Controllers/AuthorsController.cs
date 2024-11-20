using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria_JACR.Data.Services;
using Libreria_JACR.Data.ViewModels;

namespace Libreria_JACR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author) 
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        { 
            var response = _authorsService.GetAuthorWithBooks(id);        
            return Ok(response);
        }
    }
}
