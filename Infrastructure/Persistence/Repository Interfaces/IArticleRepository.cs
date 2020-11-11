using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository_Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(int articleId);
        Task<int> Create(Article newArticle);
        Task<Article> Update(int articleId, Task<Article> article);
        Task<bool> Delete(int aritcleId);
    }
}