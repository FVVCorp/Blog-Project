using MongoDB.Driver;

namespace Persistence.ContextInterfaces
{
    public interface IArticlesDbContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}