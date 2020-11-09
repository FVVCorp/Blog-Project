using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;

namespace Application.Commands
{
    public class UpdateUserCommand : IRequest<Task>
    {
        private string UserId { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Task>
        {
            private readonly IUserRepository _userRepository;

            public UpdateUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Task> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var userToUpdate = _userRepository
                    .GetUserByIdAsync(Int32.Parse(command.UserId));
                if (await userToUpdate == null) return null;
                
                var newUser = new ApplicationUser
                {
                    Id = command.UserId,
                    FirstName = command.FirstName,
                    LastName = command.LastName
                };

                await _userRepository.UpdateAsync(newUser);
                
                return default;
            }
        }
    }
}