using System.Collections;

namespace CustomCircularBuffer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CircularBuffer<Char> chars = new CircularBuffer<char>(['A','B','C'],10);
            foreach (char c in chars) 
            {
                Console.Write(c + " ");
            }
        }
    }
    class CircularBuffer<T> : IEnumerable<T>
    {
        private readonly T[] _arr;
        private readonly int _count;
        public CircularBuffer(T[] arr, int count)
        {
            _arr = arr;
            _count = count;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new CircularEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CircularEnumerator(this);
        }
        private class CircularEnumerator : IEnumerator<T>
        {
            private readonly IEnumerator<T> _enumerator;
            private CircularBuffer<T> _parent;
            private int _index = -1;
            public CircularEnumerator(CircularBuffer<T> parent)
            {
                _parent = parent;
            }

            public T Current => _parent._arr[_index % _parent._arr.Length];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_index + 1 >= _parent._count) return false;
                else
                    _index++;
                    return true;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
