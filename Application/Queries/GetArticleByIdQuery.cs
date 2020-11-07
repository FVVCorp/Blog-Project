using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetArticleByIdQuery : IRequest<Article>
    {
        public int Id { get; set; }

        public class GetArticleByIdHandler : IRequestHandler<GetArticleByIdQuery, Article>
        {
            private readonly IArticleRepository _articleRepository;

            public GetArticleByIdHandler(IArticleRepository articleRepository)
            {
                this._articleRepository = articleRepository;
            }

            public async Task<Article> Handle(GetArticleByIdQuery query, CancellationToken cancellationToken)
            {
                Task<Article> article = _articleRepository.GetArticle(query.Id);
                if (article == null) return null;
                return await article;
            }
        }
    }
}