using Persistence.SettingInterfaces;

namespace Persistence.Settings
{
    public class ArticlesDatabaseSettings : IArticlesDatabaseSettings
    {
        public string ArticlesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}