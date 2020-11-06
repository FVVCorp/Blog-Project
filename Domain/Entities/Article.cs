using Domain.Entity_Interfaces;

namespace Domain.Entities
{
    public class Article : IArticle
    {
        public int Article_ID { get; set; }
        public string Article_Text { get; set; }
        public int Article_Karma { get; set; }
        public int Author_ID { get; set; }
    }
}