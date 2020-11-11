﻿using MongoDB.Driver;
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
            return await _articles.Find(article => true).ToListAsync();
        }

        public async Task<Article> GetArticle(int articleId)
        {
            var checkArticleExistence = await _articles.Find(article => article.ArticleId == articleId).FirstOrDefaultAsync();
            if(checkArticleExistence != default)
            {
                return checkArticleExistence;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Create(Article newArticle)
        {
            await _articles.InsertOneAsync(newArticle);
            return newArticle.ArticleId;
        }

        public async Task<Article> Update(int articleId, Task<Article> newArticle)
        {
            Article article = new Article()
            {
                ArticleId = newArticle.Result.ArticleId,
                ArticleText = newArticle.Result.ArticleText,
                ArticleKarma = newArticle.Result.ArticleKarma,
                AuthorId = newArticle.Result.AuthorId
            };

            await _articles.ReplaceOneAsync(article => article.ArticleId == articleId, article);
            return article;
        }

        public async Task<bool> Delete(int articleId)
        {
            var checkArticleExistence = await _articles.Find(art => art.ArticleId == articleId).FirstOrDefaultAsync();
            if(checkArticleExistence != default)
            {
                await _articles.DeleteOneAsync(article => article.ArticleId == articleId);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}