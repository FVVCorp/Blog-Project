using MediatR;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteArticleCommand : IRequest<Task>
    {
        public int ArticleId { get; set; }
    }
}