using Libreria_JACR.Data.Services;
using Libreria_JACR.Data.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_JACR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService) 
        {
            _booksService = booksService;
        }
        [HttpGet("get-all-book")]

        public IActionResult GetAllBook()
        {
            var allbook = _booksService.GetAllBks();
            return Ok(allbook);
        }



        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }


        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }


        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updateBook = _booksService.UpdateBookById(id, book);
            return Ok(updateBook);
        }


        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
