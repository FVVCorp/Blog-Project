using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class UpdateUserCommand : IRequest<ApplicationUser>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}