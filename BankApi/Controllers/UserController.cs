using Application.CreateUserComand;
using Application.DeleteUserComand;
using Application.GetUserComand;
using Application.UpdateUserComand;
using BankApi.Dto;
using BankApi.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [ProducesResponseType<Guid>(StatusCodes.Status200OK)]
        [ProducesResponseType<Guid>(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<UserDto>> GetUser([FromRoute] Guid id, [FromServices]IGetUserComandHandler handler, CancellationToken cancellationToken)
        {
            GetUserComand comand = new(id);
            try
            {
                User? user = await handler.HandleAsync(comand, cancellationToken);
                UserDto userDto = new(user.Id, user.Name);
                return Ok(userDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateUser(CreateUserRequest request, [FromServices] ICreateUserComandHandler handler, CancellationToken cancellationToken)
        {
            CreateUserComand comand = new(request.Name);
            Guid user = await handler.HandleAsync(comand, cancellationToken);
            return Created(string.Empty, user);
        }

        // PUT api/<UserController>/5
        [HttpPatch("{id}")]
        [ProducesResponseType<Guid>(StatusCodes.Status200OK)]
        [ProducesResponseType<Guid>(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest request, [FromServices]IUpdateUserComandHandler handler, CancellationToken cancellationToken)
        {
            UpdateUserComand comand = new(id, request.Name);
            try
            {
                await handler.HandAsync(comand, cancellationToken);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType<Guid>(StatusCodes.Status204NoContent)]

        public async Task<ActionResult> DeleteUser([FromRoute]Guid id, [FromServices]IDeleteUserComandHandler handler, CancellationToken cancellationToken)
        {
            DeleteUserComand comand = new(id);
            await handler.HandleAsync(comand, cancellationToken);
            return NoContent();
        }
    }
}
