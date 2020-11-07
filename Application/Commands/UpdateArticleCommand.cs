using MediatR;
using Persistence.Repository_Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateArticleCommand : IRequest<Task>
    {
        public int Article_ID { get; set; }
        public string Article_Text { get; set; }
        public int Article_Karma { get; set; }
        public int Author_ID { get; set; }

        public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Task>
        {
            private readonly IArticleRepository _articleRepository;

            public UpdateArticleCommandHandler(IArticleRepository articleRepository)
            {
                this._articleRepository = articleRepository;
            }

            public async Task<Task> Handle(UpdateArticleCommand command, CancellationToken cancellationToken)
            {
                var article = _articleRepository.GetArticle(command.Article_ID);

                if (article != null)
                {
                    article.Result.Article_ID = command.Article_ID;
                    article.Result.Article_Text = command.Article_Text;
                    article.Result.Article_Karma = command.Article_Karma;
                    article.Result.Author_ID = command.Author_ID;

                    await this._articleRepository.Update(command.Article_ID, article);

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