using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;

namespace Application.Queries
{
    public class GetUserByIdQuery : IRequest<ApplicationUser>
    {
        private int Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApplicationUser>
        {
            private readonly IUserRepository _userRepository;

            public GetUserByIdQueryHandler(IUserRepository userRepository)
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
}