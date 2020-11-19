using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<ApplicationUser>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}