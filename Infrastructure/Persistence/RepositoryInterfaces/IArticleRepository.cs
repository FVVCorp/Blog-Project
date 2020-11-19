using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.RepositoryInterfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticles();
        Task<Article> GetArticleById(int articleId);
        Task<int> CreateArticle(Article newArticle);
        Task<Article> UpdateArticle(Article article);
        Task<bool> DeleteArticle(int aritcleId);
    }
}