using Application.Queries;
using Domain.Entities;
using MediatR;
using Persistence.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandlers
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, IEnumerable<Article>>
    {
        private readonly IArticleRepository _articleRepository;

        public GetAllArticlesQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<Article>> Handle(GetAllArticlesQuery query, CancellationToken cancellationToken)
        {
            Task<IEnumerable<Article>> articles = _articleRepository.GetAllArticles();
            if (articles.Result == null) return null;
            return await articles;
        }
    }
}