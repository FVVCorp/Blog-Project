using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries
{
    public class GetAllArticlesQuery : IRequest<IEnumerable<Article>>
    {

    }
}