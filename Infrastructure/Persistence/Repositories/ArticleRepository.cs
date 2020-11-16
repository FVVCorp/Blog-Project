using MongoDB.Driver;
using Persistence.RepositoryInterfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using Persistence.ContextInterfaces;

namespace Persistence.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IArticlesDbContext _context;
        private readonly IMongoCollection<Article> _articles;

        public ArticleRepository(IArticlesDbContext context)
        {
            try
            {
                _context = context;
                _articles = _context.GetCollections<Article>();
            }
            catch(Exception e)
            {
                Debug.WriteLine($"MongoDB database didn't connect.\tException message: {e.Message}");
            }
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            try
            {
                var checkArticlesExistence = await _articles.Find(article => true).ToListAsync();
                return checkArticlesExistence;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"GetAllArticles() is failed!\tException message: {e.Message}");
                return null;
            }
        }

        public async Task<Article> GetArticleById(int articleId)
        {
            try
            {
                var checkArticleExistence = await _articles.Find(art => art.ArticleId == articleId).FirstOrDefaultAsync();
                return checkArticleExistence;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"GetArticleById() is failed!\tException message: {e.Message}");
                return null;
            }
                        
        }

        public async Task<int> CreateArticle(Article newArticle)
        {
            try
            {
                if(!string.IsNullOrEmpty(newArticle.ArticleText) && newArticle.ArticleText.Length >= 25)
                {
                    var maxArticleId = await _articles.Find(x => true).SortByDescending(a => a.ArticleId).Limit(1).FirstOrDefaultAsync();
                    var defaultAuthorId = await _articles.Find(x => true).FirstOrDefaultAsync();

                    newArticle.ArticleId = maxArticleId.ArticleId + 1;
                    newArticle.AuthorId = defaultAuthorId.AuthorId;

                    await _articles.InsertOneAsync(newArticle, null);

                    return newArticle.ArticleId;
                }
                else
                {
                    throw new NullReferenceException("Text for intserted article is null or empty");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"CreateArticle() is failed!\tException message: {e.Message}");
                return default;
            }
        }

        public async Task<Article> UpdateArticle(Article newArticle)
        {
            try
            {
                var getArticleById = await GetArticleById(newArticle.ArticleId);
                if(getArticleById != null && newArticle.ArticleText.Length < 25)
                {
                    getArticleById.ArticleKarma = newArticle.ArticleKarma;
                    getArticleById.ArticleText = newArticle.ArticleText;

                    await _articles.ReplaceOneAsync(a => a.ArticleId == newArticle.ArticleId, getArticleById);
                    return await GetArticleById(newArticle.ArticleId);
                }
                else
                {
                    throw new NullReferenceException("Article with current id doesn't exits");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"UpdateArticle() is failed!\tException message: {e.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteArticle(int articleId)
        {
            try
            {
                var checkArticleExistence = await _articles.Find(art => art.ArticleId == articleId).FirstOrDefaultAsync();
                if(checkArticleExistence != null)
                {
                    await _articles.DeleteOneAsync(article => article.ArticleId == articleId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Article DeleteArticle() is failed!\tException message: {e.Message}");
                return false;
            }
        }
    }
}