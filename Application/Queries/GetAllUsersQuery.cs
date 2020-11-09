using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;

namespace Application.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<ApplicationUser>>
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
                var users = _userRepository.GetUsersAsync();
                
                if (users == null) return null;

                return await users;
            }
        }
    }
}