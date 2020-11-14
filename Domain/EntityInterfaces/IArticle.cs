namespace Domain.Entity_Interfaces
{
    public interface IArticle
    {
        string AutoId { get; set; }
        int ArticleId { get; set; }
        string ArticleText { get; set; }
        int ArticleKarma { get; set; }
        int AuthorId { get; set; }
    }
}