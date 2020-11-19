using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using MediatR;
using Persistence.RepositoryInterfaces;

namespace Application.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(command.Id);
                
            if (user == null) return false;
                
            await _userRepository.DeleteAsync(command.Id);
                
            return true;
        }
    }
}