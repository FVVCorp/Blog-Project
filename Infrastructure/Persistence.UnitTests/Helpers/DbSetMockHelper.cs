using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence.UnitTests.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Persistence.UnitTests.Helpers
{
    public static class DbSetMockHelper
    {
        public static Mock<DbSet<T>> Get<T>(IQueryable<T> data) where T : class
        {
            var dbSet = new Mock<DbSet<T>>();

            // for async expressions
            dbSet
                .As<IAsyncEnumerable<T>>()
                .Setup(x => x.GetAsyncEnumerator(It.IsAny<CancellationToken>()))      
                .Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));

            // for sync expressions
            dbSet
                .As<IQueryable<T>>()
                .Setup(x => x.Provider)
                .Returns(new TestAsyncQueryProvider<T>(data.Provider));

            dbSet
                .As<IQueryable<T>>()
                .Setup(x => x.Expression)
                .Returns(data.Expression);

            dbSet
                .As<IQueryable<T>>()
                .Setup(x => x.ElementType)
                .Returns(data.ElementType);

            dbSet
                .As<IQueryable<T>>()
                .Setup(x => x.GetEnumerator())
                .Returns(data.GetEnumerator());
            
            return dbSet;
        }
    }
}