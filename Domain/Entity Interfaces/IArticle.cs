namespace Domain.Entity_Interfaces
{
    public interface IArticle
    {
        string _id { get; set; }
        int Article_ID { get; set; }
        string Article_Text { get; set; }
        int Article_Karma { get; set; }
        int Author_ID { get; set; }
    }
}