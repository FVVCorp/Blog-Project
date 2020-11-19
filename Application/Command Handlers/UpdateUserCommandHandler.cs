using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Domain.Entities;
using MediatR;
using Persistence.RepositoryInterfaces;

namespace Application.Command_Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ApplicationUser>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository
                .GetUserByIdAsync(command.Id);
            if (userToUpdate == null) return null;

            var newUser = new ApplicationUser
            {
                FirstName = command.FirstName,
                LastName = command.LastName
            };

            await _userRepository.UpdateAsync(newUser);

            return newUser;
        }
    }
}