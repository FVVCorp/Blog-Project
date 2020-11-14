using Application.Commands;
using Domain.Entities;
using MediatR;
using Persistence.RepositoryInterfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Article>
    {
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Article> Handle(UpdateArticleCommand command, CancellationToken cancellationToken)
        {
            var article = new Article()
            {
                ArticleId = command.ArticleId,
                ArticleText = command.ArticleText,
                ArticleKarma = command.ArticleKarma
            };

            return await _articleRepository.UpdateArticle(article);
        }
    }
}