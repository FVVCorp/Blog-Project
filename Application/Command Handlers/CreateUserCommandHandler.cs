using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Domain.Entities;
using MediatR;
using Persistence.RepositoryInterfaces;

namespace Application.Command_Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApplicationUser>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                FirstName = command.FirstName,
                LastName = command.LastName
            };
            
            await _userRepository.CreateAsync(user);
            
            return user;
        }
    }
}