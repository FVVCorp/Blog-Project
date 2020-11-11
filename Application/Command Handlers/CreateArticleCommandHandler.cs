using Application.Commands;
using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
    {
        private readonly IArticleRepository _articleRepository;

        public CreateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<int> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            var article = new Article
            {
                ArticleId = command.ArticleId,
                ArticleText = command.ArticleText,
                ArticleKarma = command.ArticleKarma,
                AuthorId = command.AuthorId
            };

            await _articleRepository.Create(article);

            return article.ArticleId;
        }
    }
}
