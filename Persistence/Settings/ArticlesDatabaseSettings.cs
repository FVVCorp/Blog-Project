using Persistence.Setting_Interfaces;

namespace Persistence.Settings
{
    public class ArticlesDatabaseSettings : IArticlesDatabaseSettings
    {
        public string ArticlesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}