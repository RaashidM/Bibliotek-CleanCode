using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Commands.DeleteAuthor;
using Application.Authors.Commands.UpdateAuthor;
using Application.Authors.Queries.GetAllAuthors;
using Application.Authors.Queries.GetAuthorById;
using Domain;
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
       

        public AuthorController(IMediator mediatr)
        {
            _mediatr = mediatr;
            
        }
        // GET: api/<AuthorController>
        [Authorize]
        [HttpGet]
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(Guid id)
        {
            try
            {
                var authors = await _mediatr.Send(new GetAuthorByIdQuery(id));

                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAuthorCommand addCommand)
        {
            
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
        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> Put(Guid id, [FromBody] UpdateAuthorCommand updateAuthorCommand)
        {
            if (id != updateAuthorCommand.AuthorId)
            {
                return BadRequest("The author ID do not match.");
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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediatr.Send(new DeleteAuthorCommand(id));
            return NoContent();
        }
    }
}
