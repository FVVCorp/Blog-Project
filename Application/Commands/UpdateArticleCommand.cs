using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class UpdateArticleCommand : IRequest<Article>
    {
        public int ArticleId { get; private set; }
        public string ArticleText { get; private set; }
        public int ArticleKarma { get; private set; }

        public UpdateArticleCommand(Article article)
        {
            ArticleId = article.ArticleId;
            ArticleText = article.ArticleText;
            ArticleKarma = article.ArticleKarma;
        }
    }
}