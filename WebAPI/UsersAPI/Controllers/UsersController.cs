using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery {Id = id}));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(ApplicationUser user)
        {
            return Ok(await _mediator.Send(new CreateUserCommand
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {    
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand {Id = id}));
        }
    }
}