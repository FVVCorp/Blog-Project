using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreateArticleCommand : IRequest<int>
    {
        public string ArticleText { get; private set; }

        public CreateArticleCommand(Article article)
        {
            ArticleText = article.ArticleText;
        }
    }
}