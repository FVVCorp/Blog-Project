using MediatR;

namespace Application.Commands
{
    public class DeleteArticleCommand : IRequest<bool>
    {
        public int ArticleId { get; set; }

        public DeleteArticleCommand(int articleId)
        {
            ArticleId = articleId;
        }
    }
}