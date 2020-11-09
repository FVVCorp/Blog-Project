using Domain.Entity_Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Article : IArticle
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int Article_ID { get; set; }
        public string Article_Text { get; set; }
        public int Article_Karma { get; set; }
        public int Author_ID { get; set; }
    }
}