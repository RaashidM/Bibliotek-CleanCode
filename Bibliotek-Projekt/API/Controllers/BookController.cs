using Application.Books.Commands;
using Application.Books.Commands.DeleteBook;
using Application.Books.Commands.UpdateBook;
using Application.Books.Queries.GetBookById;
using Application.Books.Queries.GetBooks;
using Domain;
using FluentValidation;
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
        private readonly IValidator<CreateBookCommand> _createBookValidator;
        private readonly IValidator<UpdateBookCommand> _updateBookValidator;

        public BookController(IMediator mediatr,
           IValidator<CreateBookCommand> createBookValidator,
           IValidator<UpdateBookCommand> updateBookValidator)
        {
            _mediatr = mediatr;
            _createBookValidator = createBookValidator;
            _updateBookValidator = updateBookValidator;
        }


        // GET: api/<BookController>
        [Authorize]
        [HttpGet("GetAllBooks")]
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

        // GET api/<BookController>/5
        [HttpGet("GetBookById")]
        public async Task<ActionResult<Book>> Get(Guid id)
        {
            try
            {
                var operationResult = await _mediatr.Send(new GetBookByIdQuery(id));

                if (operationResult.IsSuccesfull)
                {
                    return Ok(new {message = operationResult.Message, data = operationResult.Data});
                }
                else
                {
                    return BadRequest(new {message = operationResult.Message, errors = operationResult.ErrorMessage });
                }
                
                
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<BookController>
        [HttpPost("CreateBook")]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand bookToAdd)
        {
            var validationResult = await _createBookValidator.ValidateAsync(bookToAdd);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var result = await _mediatr.Send(bookToAdd);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<BookController>/5

        [HttpPut("UpdateBook")]
        public async Task<ActionResult<Book>> Put(Guid id, [FromBody] UpdateBookCommand updateBookCommand)
        {
            if (id != updateBookCommand.BookId)
            {
                return BadRequest("The book ID do not match.");
            }

            var validationResult = await _updateBookValidator.ValidateAsync(updateBookCommand);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
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
        [HttpDelete("DeleteBook")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediatr.Send(new DeleteBookCommand(id));
            return NoContent();
        }
    }
}
