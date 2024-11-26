using Application.Books.Commands;
using Application.Books.Commands.DeleteBook;
using Application.Books.Commands.UpdateBook;
using Application.Books.Queries.GetBooks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public BookController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        // GET: api/<BookController>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            try
            {

                var books = await _mediatr.Send(new GetAllBooksQuery());


                return Ok(books);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        //// GET api/<BookController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<BookController>
        [HttpPost]
        public async void Post([FromBody] Book bookToAdd)
        {
            await _mediatr.Send(new CreateBookCommand(bookToAdd));
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, [FromBody] UpdateBookCommand updateBookCommand)
        {
            if (id != updateBookCommand.BookId)
            {
                return BadRequest("The book ID in the URL and the body do not match.");
            }

            try
            {
                var updateBook = await _mediatr.Send(updateBookCommand);

                return Ok(updateBook);
            }

            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediatr.Send(new DeleteBookCommand(id));
            return NoContent();
        }
    }
}
