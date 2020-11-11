using Application.Commands;
using MediatR;
using Persistence.Repository_Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, bool>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<bool> Handle(DeleteArticleCommand command, CancellationToken cancellationToken)
        {
            var article = _articleRepository.GetArticle(command.ArticleId);

            if (article.Result != null)
            {
                await _articleRepository.Delete(command.ArticleId);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}