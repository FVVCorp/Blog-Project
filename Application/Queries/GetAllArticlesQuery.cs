using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllArticlesQuery : IRequest<IEnumerable<Article>>
    {
        public class GetArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, IEnumerable<Article>>
        {
            private readonly IArticleRepository _articleRepository;

            public GetArticlesQueryHandler(IArticleRepository articleRepository)
            {
                this._articleRepository = articleRepository;
            }

            public async Task<IEnumerable<Article>> Handle(GetAllArticlesQuery query, CancellationToken cancellationToken)
            {
                Task<IEnumerable<Article>> articles = this._articleRepository.GetArticles();
                if (articles == null) return null;
                return await articles;
            }
        }
    }
}