using Domain.Entities;
using System.Collections.Generic;

namespace Persistence.UnitTests
{
    public class ArticleRepositoryTests
    {
        private readonly Article _article = new Article()
        {
            ArticleText = "Test",
            ArticleKarma = 2
        };

        private readonly Article _articleWithoutArticleId = new Article()
        {
            ArticleText = "X Test",
            ArticleKarma = 5,
        };

        private readonly IEnumerable<Article> _articles = new List<Article>()
        {
            new Article() {             
                ArticleText = "Test",
                ArticleKarma = 5
            },
            new Article()
            {
                ArticleText = "Test Test",
                ArticleKarma = 10
            }
        };
    }
}