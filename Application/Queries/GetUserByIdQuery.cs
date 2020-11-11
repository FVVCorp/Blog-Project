using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetUserByIdQuery : IRequest<ApplicationUser>
    {
        public int Id { get; set; }
    }
}