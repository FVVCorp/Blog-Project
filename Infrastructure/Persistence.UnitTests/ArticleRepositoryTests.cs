using System.Threading.Tasks;
using Xunit;
using Moq;
using Domain.Entities;
using Persistence.RepositoryInterfaces;
using System.Collections.Generic;
using Persistence.SettingInterfaces;
using Persistence.Repositories;

namespace Persistence.UnitTests
{
    public class ArticleRepositoryTests
    {
        private readonly Article _article = new Article()
        {
            ArticleId = 3,
            ArticleText = "Test",
            ArticleKarma = 2,
            AuthorId = 1
        };

        private readonly Article _articleWithoutArticleId = new Article()
        {
            ArticleText = "X Test",
            ArticleKarma = 5,
            AuthorId = 1
        };

        private readonly IEnumerable<Article> _articles = new List<Article>()
        {
            new Article() {             
                ArticleId = 1,
                ArticleText = "Test",
                ArticleKarma = 5,
                AuthorId = 1
            },
            new Article()
            {
                ArticleId = 2,
                ArticleText = "Test Test",
                ArticleKarma = 10,
                AuthorId = 1
            }
        };
    }
}