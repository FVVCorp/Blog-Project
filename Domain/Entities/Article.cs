using Domain.Entity_Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Article : IArticle
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string AutoId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleText { get; set; }
        public int ArticleKarma { get; set; }
        public int AuthorId { get; set; }
    }
}