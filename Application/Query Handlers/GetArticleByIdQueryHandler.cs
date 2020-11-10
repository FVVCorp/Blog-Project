using Application.Queries;
using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Query_Handlers
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Article>
    {
        private readonly IArticleRepository _articleRepository;

        public GetArticleByIdQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Article> Handle(GetArticleByIdQuery query, CancellationToken cancellationToken)
        {
            Task<Article> article = _articleRepository.GetArticle(query.ArticleId);
            if (article.Result == null) return null;
            return await article;
        }
    }
}