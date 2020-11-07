using MediatR;
using Persistence.Repository_Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteArticleCommand : IRequest<Task>
    {
        public int Article_ID { get; set; }

        public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Task>
        {
            private readonly IArticleRepository _articleRepository;

            public DeleteArticleCommandHandler(IArticleRepository articleRepository)
            {
                this._articleRepository = articleRepository;
            }

            public async Task<Task> Handle(DeleteArticleCommand command, CancellationToken cancellationToken)
            {
                var article = this._articleRepository.GetArticle(command.Article_ID);

                if (article != null)
                {
                    await this._articleRepository.Delete(command.Article_ID);
                    return Task.CompletedTask;
                }
                else
                {
                    return default;
                }
            }
        }
    }
}