using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence.Repository_Interfaces;

namespace Application.Commands
{
    public class DeleteUserCommand : IRequest<Task>
    {
        private int UserId { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Task>
        {
            private readonly IUserRepository _userRepository;

            public DeleteUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Task> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
            {
                var user = _userRepository.GetUserByIdAsync(command.UserId);
                
                if (await user == null) return default;
                
                await _userRepository.DeleteAsync(command.UserId);
                
                return Task.CompletedTask;

            }
        }
    }
}