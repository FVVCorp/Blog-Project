using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.UnitTests.Utils
{
    public class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _data;

        public TestAsyncEnumerator(IEnumerator<T> data)
        {
            _data = data;
        }

        public T Current => _data.Current;

        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(_data.MoveNext());

        public ValueTask DisposeAsync()
        {
            _data.Dispose();

            return new ValueTask();
        }
    }
}