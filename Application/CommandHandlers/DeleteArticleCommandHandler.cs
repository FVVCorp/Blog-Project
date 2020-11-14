using Application.Commands;
using MediatR;
using Persistence.RepositoryInterfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers
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
            return await _articleRepository.DeleteArticle(command.ArticleId);
        }
    }
}