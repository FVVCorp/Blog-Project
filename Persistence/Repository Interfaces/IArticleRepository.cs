using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository_Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(int Article_ID);
        Task Create(Article newArticle);
        Task Update(int Article_ID, Task<Article> article);
        Task Delete(int Acticle_ID);
    }
}