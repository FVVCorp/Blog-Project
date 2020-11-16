using Persistence.ContextInterfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Persistence.Settings;

namespace Persistence.Contexts
{
    public class ArticlesDbContext : IArticlesDbContext 
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        private IOptions<ArticlesDbSettings> _config { get; set; }

        public ArticlesDbContext(IOptions<ArticlesDbSettings> config)
        {
            _config = config;
            _mongoClient = new MongoClient(_config.Value.Connection);
            _db = _mongoClient.GetDatabase(_config.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollections<T>()
        {
            return _db.GetCollection<T>(_config.Value.CollectionName);
        }
    }
}