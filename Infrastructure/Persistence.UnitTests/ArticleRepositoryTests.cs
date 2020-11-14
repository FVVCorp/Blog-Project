using System.Threading.Tasks;
using Xunit;
using Moq;
using Domain.Entities;
using Persistence.RepositoryInterfaces;
using System.Collections.Generic;

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

        private readonly Mock<IArticleRepository> _articleRepoMock = new Mock<IArticleRepository>();

        [Fact]
        public async Task GetArticleById_ShouldReturnArticle_ArticleExistsInDb()
        {
            _articleRepoMock.Setup(a => a.GetArticleById(_article.ArticleId))
                .ReturnsAsync(_article);
            IArticleRepository articleRepository = _articleRepoMock.Object;
            var getArticleById = await articleRepository.GetArticleById(3);

            Assert.NotNull(getArticleById);
            Assert.IsType(_article.GetType(), getArticleById);
            Assert.Equal(_article, getArticleById);
        }

        [Fact]
        public async Task GetArticleById_ShouldReturnNull_ArticleDoesntExistInDb()
        {
            IArticleRepository articleRepository = _articleRepoMock.Object;
            var getArticleById = await articleRepository.GetArticleById(3);

            Assert.Null(getArticleById);
        }

        [Fact]
        public async Task GetAllArticles_ShouldReturnCollectionOfArticles_ArticlesExistInDb()
        {
            _articleRepoMock.Setup(a => a.GetAllArticles()).ReturnsAsync(_articles);
            IArticleRepository articleRepository = _articleRepoMock.Object;
            var getAllArticles = await articleRepository.GetAllArticles();

            Assert.NotNull(getAllArticles);
            Assert.IsType(_articles.GetType(), getAllArticles);
        }

        [Fact]
        public async Task GetAllArticles_ShouldReturnEmptyCollection_CollectionOfArticlesIsntInitialilzedInDb()
        {
            IArticleRepository articleRepository = _articleRepoMock.Object;
            var getAllArticles = await articleRepository.GetAllArticles();

            Assert.Empty(getAllArticles);
        }

        [Fact]
        public async Task CreateArticle_ShouldReturnArticleIdOfNewArticle_NewArticleObjectIsCorrect()
        {
            _articleRepoMock.Setup(a => a.CreateArticle(_article)).ReturnsAsync(_article.ArticleId);
            IArticleRepository articleRepository = _articleRepoMock.Object;
            var createArticle = await articleRepository.CreateArticle(_article);

            Assert.Equal(_article.ArticleId, createArticle);
        }

        [Fact]
        public async Task CreateArticle_ShouldReturnDefaultIntValue_ArticleIdIsntSet()
        {
            _articleRepoMock.Setup(a => a.CreateArticle(_articleWithoutArticleId))
                .ReturnsAsync(_articleWithoutArticleId.ArticleId);
            IArticleRepository articleRepository = _articleRepoMock.Object;
            var createArticle = await articleRepository.CreateArticle(_articleWithoutArticleId);

            Assert.Equal(_articleWithoutArticleId.ArticleId, createArticle);
            Assert.Equal(default, createArticle);
        }

        [Fact]
        public async Task UpdateArticle_ShouldReturnUpdatedArticle_ArticleForUpdateIsCorrect()
        {
            _articleRepoMock.Setup(a => a.UpdateArticle(_article)).ReturnsAsync(_article);
            IArticleRepository articleRepository = _articleRepoMock.Object;
            var updateArticle = await articleRepository.UpdateArticle(_article);

            Assert.NotNull(updateArticle);
            Assert.Equal(_article, updateArticle);
        }

        [Fact]
        public async Task DeleteArticle_ShouldReturnTrue_IfArticleIsSuccessfullyDeleted()
        {
            _articleRepoMock.Setup(a => a.DeleteArticle(_article.ArticleId)).ReturnsAsync(true);
            IArticleRepository articleRepository = _articleRepoMock.Object;
            var deleteArticle = await articleRepository.DeleteArticle(_article.ArticleId);

            Assert.True(deleteArticle);
        }

        [Fact]
        public async Task DeleteArticle_ShouldReturnFalse_IfArticleWithCurrentIdDoesntExistOrSmthingWentWrong()
        {
            _articleRepoMock.Setup(a => a.DeleteArticle(_articleWithoutArticleId.ArticleId)).ReturnsAsync(false);
            IArticleRepository articleRepository = _articleRepoMock.Object;
            var deleteArticle = await articleRepository.DeleteArticle(_articleWithoutArticleId.ArticleId);

            Assert.False(deleteArticle);
        }
    }
}