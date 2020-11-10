using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetArticleByIdQuery : IRequest<Article>
    {
        public int ArticleId { get; set; }
    }
}