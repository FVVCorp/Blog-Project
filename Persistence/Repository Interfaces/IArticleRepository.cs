using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository_Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(int articleId);
        Task Create(Article newArticle);
        Task Update(int articleId, Task<Article> article);
        Task Delete(int aritcleId);
    }
}