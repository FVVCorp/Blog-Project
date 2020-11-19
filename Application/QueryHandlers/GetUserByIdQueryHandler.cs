using System.Threading;
using System.Threading.Tasks;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Persistence.RepositoryInterfaces;

namespace Application.QueryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApplicationUser>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository  userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> Handle(GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByIdAsync(request.Id);
                
            if (user == null) return null;
                
            return await user;
        }
    }
}