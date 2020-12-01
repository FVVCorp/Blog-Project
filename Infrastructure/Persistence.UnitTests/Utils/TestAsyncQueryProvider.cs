using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace Persistence.UnitTests.Utils
{
    public class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _data;

        internal TestAsyncQueryProvider(IQueryProvider data)
        {
            _data = data;
        }

        public IQueryable CreateQuery(Expression expression) => new TestAsyncEnumerable<TEntity>(expression);
        
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => new TestAsyncEnumerable<TElement>(expression);

        public object Execute(Expression expression) => _data.Execute(expression);

        public TResult Execute<TResult>(Expression expression) => _data.Execute<TResult>(expression);
        
        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken token) => Execute<TResult>(expression);
    }
}