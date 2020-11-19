using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Persistence.RepositoryInterfaces;

namespace Application.Query_Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<ApplicationUser>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUser>> Handle(GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersAsync();
            
            return users;
        }
    }
}