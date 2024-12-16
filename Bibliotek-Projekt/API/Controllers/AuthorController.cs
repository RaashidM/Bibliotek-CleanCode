using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Commands.DeleteAuthor;
using Application.Authors.Commands.UpdateAuthor;
using Application.Authors.Queries.GetAllAuthors;
using Application.Authors.Queries.GetAuthorById;
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
    public class AuthorController : ControllerBase
    {

        private readonly IMediator _mediatr;
        private readonly IValidator<CreateAuthorCommand> _createAuthorValidator;
        private readonly IValidator<UpdateAuthorCommand> _updateAuthorValidator;


        public AuthorController(IMediator mediatr,
             IValidator<CreateAuthorCommand> createAuthorValidator,
             IValidator<UpdateAuthorCommand> updateAuthorValidator)
        {
            _mediatr = mediatr;
            _createAuthorValidator = createAuthorValidator;
            _updateAuthorValidator = updateAuthorValidator;
            
        }
        // GET: api/<AuthorController>
        [Authorize]
        [HttpGet("GetAllAuthors")]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            try
            {

                var authors = await _mediatr.Send(new GetAllAuthorsQuery());


                return Ok(authors);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<AuthorController>/5
        [HttpGet("GetAuthorById")]
        public async Task<ActionResult<Author>> Get(Guid id)
        {
            try
            {
                var operationResult = await _mediatr.Send(new GetAuthorByIdQuery(id));

                if (operationResult.IsSuccesfull)
                {
                    return Ok(new {message = operationResult.Message, data = operationResult.Data});
                }
                else
                {
                    return BadRequest(new { message = operationResult.Message, errors = operationResult.ErrorMessage});
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<AuthorController>
        [HttpPost("AddAuthor")]
        public async Task<IActionResult> Post([FromBody] CreateAuthorCommand addCommand)
        {
            var validationResult = await _createAuthorValidator.ValidateAsync(addCommand);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var result = await _mediatr.Send(addCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // PUT api/<AuthorController>/5
        [HttpPut("UpdateAuthor")]
        public async Task<ActionResult<Author>> Put(Guid id, [FromBody] UpdateAuthorCommand updateAuthorCommand)
        {
            if (id != updateAuthorCommand.AuthorId)
            {
                return BadRequest("The author ID do not match.");
            }

            var validationResult = await _updateAuthorValidator.ValidateAsync(updateAuthorCommand);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var updateAuthor = await _mediatr.Send(updateAuthorCommand);
                return Ok(updateAuthor);
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
    


        // DELETE api/<AuthorController>/5
        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediatr.Send(new DeleteAuthorCommand(id));
            return NoContent();
        }
    }
}
