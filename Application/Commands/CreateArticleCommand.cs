using Domain.Entities;
using MediatR;
using Persistence.Repository_Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateArticleCommand : IRequest<Task>
    {
        public int Article_ID { get; set; }
        public string Article_Text { get; set; }
        public int Article_Karma { get; set; }
        public int Author_ID { get; set; }

        public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Task>
        {
            private readonly IArticleRepository _articleRepository;

            public CreateArticleCommandHandler(IArticleRepository articleRepository)
            {
                this._articleRepository = articleRepository;
            }

            public async Task<Task> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
            {
                var article = new Article
                {
                    Article_ID = command.Article_ID,
                    Article_Text = command.Article_Text,
                    Article_Karma = command.Article_Karma,
                    Author_ID = command.Author_ID
                };

                await this._articleRepository.Create(article);

                return default;
            }
        }
    }
}