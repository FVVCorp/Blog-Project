using Application.Commands;
using Domain.Entities;
using MediatR;
using Persistence.RepositoryInterfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers
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
                ArticleText = command.ArticleText
            };

            return await _articleRepository.CreateArticle(article);
        }
    }
}
