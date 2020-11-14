namespace Persistence.SettingInterfaces
{
    public interface IArticlesDatabaseSettings
    {
        string ArticlesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}