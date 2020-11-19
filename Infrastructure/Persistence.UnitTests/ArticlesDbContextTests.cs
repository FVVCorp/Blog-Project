using Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using Persistence.Contexts;
using Persistence.Settings;
using Xunit;
using System;

namespace Persistence.UnitTests
{
    public class ArticlesDbContextTests
    {
        private Mock<IOptions<ArticlesDbSettings>> _mockOptions;

        private Mock<IMongoDatabase> _mockDb;

        private Mock<IMongoClient> _mockClient;

        public ArticlesDbContextTests()
        {
            _mockOptions = new Mock<IOptions<ArticlesDbSettings>>();
            _mockDb = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();
        }

        [Fact]
        public void ArticlesDbContext_Construcor_Success()
        {
            // Arrange
            var settings = new ArticlesDbSettings()
            {
                Connection = "mongodb://test",
                DatabaseName = "TestDb"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDb.Object);

            // Act
            var context = new ArticlesDbContext(_mockOptions.Object);

            // Assert
            Assert.NotNull(context);
        }

        [Fact]
        public void ArticlesDbContext_GetCollection_NameEmpty_Failure()
        {
            // Arrange
            var settings = new ArticlesDbSettings()
            {
                Connection = "mongodb://test",
                DatabaseName = "TestDb",
                CollectionName = string.Empty
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
            .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDb.Object);

            //Act 
            var context = new ArticlesDbContext(_mockOptions.Object);

            //Assert 
            Assert.Throws<ArgumentException>(() => context.GetCollection<Article>());
        }

        [Fact]
        public void ArticlesDbContext_GetCollection_ValidName_Success()
        {
            // Arrange
            var settings = new ArticlesDbSettings()
            {
                Connection = "mongodb://test",
                DatabaseName = "TestDb",
                CollectionName = "Test"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
            .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDb.Object);

            //Act 
            var context = new ArticlesDbContext(_mockOptions.Object);
            var collection = context.GetCollection<Article>();

            //Assert 
            Assert.NotNull(collection);
        }
    }
}