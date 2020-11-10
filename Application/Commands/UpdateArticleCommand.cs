using MediatR;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateArticleCommand : IRequest<Task>
    {
        public int ArticleId { get; set; }
        public string ArticleText { get; set; }
        public int ArticleKarma { get; set; }
        public int AuthorId { get; set; }
    }
}