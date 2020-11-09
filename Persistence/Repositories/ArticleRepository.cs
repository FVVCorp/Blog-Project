using MongoDB.Driver;
using Persistence.Repository_Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using Persistence.Setting_Interfaces;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IMongoCollection<Article> _articles;

        public ArticleRepository(IArticlesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _articles = db.GetCollection<Article>(settings.ArticlesCollectionName);
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await this._articles.Find(article => true).ToListAsync();
        }

        public async Task<Article> GetArticle(int Article_ID)
        {
            return await this._articles.Find(article => article.Article_ID == Article_ID).FirstOrDefaultAsync();
        }

        public async Task Create(Article newArticle)
        {
            await this._articles.InsertOneAsync(newArticle);
        }


        public async Task Update(int Article_ID, Task<Article> _article)
        {
            Article article = new Article()
            {
                Article_ID = _article.Result.Article_ID,
                Article_Text = _article.Result.Article_Text,
                Article_Karma = _article.Result.Article_Karma,
                Author_ID = _article.Result.Author_ID
            };

            await this._articles.ReplaceOneAsync(article => article.Article_ID == Article_ID, article);
        }

        public async Task Delete(int Article_ID)
        {
            await this._articles.DeleteOneAsync(article => article.Article_ID == Article_ID);
        }
    }
}