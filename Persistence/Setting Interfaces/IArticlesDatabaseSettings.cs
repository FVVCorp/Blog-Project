namespace Persistence.Setting_Interfaces
{
    public interface IArticlesDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}