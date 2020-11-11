using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using MediatR;
using Persistence.Repository_Interfaces;

namespace Application.Command_Handlers
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
            var user = _userRepository.GetUserByIdAsync(command.Id);
                
            if (await user == null) return false;
                
            await _userRepository.DeleteAsync(command.Id);
                
            return true;
        }
    }
}