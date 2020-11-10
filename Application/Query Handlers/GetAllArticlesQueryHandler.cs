using Application.Queries;
using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Query_Handlers
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
            Task<IEnumerable<Article>> articles = _articleRepository.GetArticles();
            if (articles.Result == null) return null;
            return await articles;
        }
    }
}