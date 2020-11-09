using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<Task>
    {
        private string UserId { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Task>
        {
            private readonly IUserRepository _userRepository;

            public CreateUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Task> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = new ApplicationUser
                {
                    Id = command.UserId,
                    FirstName = command.FirstName,
                    LastName = command.LastName
                };
                
                await _userRepository.CreateAsync(user);
                
                return default;
            }
        }
    }
}