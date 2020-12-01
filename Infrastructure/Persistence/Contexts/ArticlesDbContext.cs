using Persistence.ContextInterfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Persistence.Settings;

namespace Persistence.Contexts
{
    public class ArticlesDbContext : IArticlesDbContext 
    {
        private IMongoDatabase Db { get; set; }
        private MongoClient MongoClient { get; set; }
        private IOptions<ArticlesDbSettings> Config { get; set; }

        public ArticlesDbContext(IOptions<ArticlesDbSettings> config)
        {
            Config = config;
            MongoClient = new MongoClient(Config.Value.Connection);
            Db = MongoClient.GetDatabase(Config.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return Db.GetCollection<T>(Config.Value.CollectionName);
        }
    }
}