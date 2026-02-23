using System.Collections;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Contains (9): " + list.Contains(9));
            Console.WriteLine("IndexOf (5): " + list.IndexOf(5));
            Console.WriteLine("Inserting 50 in index - 4:\n");
            list.Insert(4, 50);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Clear:\n");
            list.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.ReadLine();
        }
    }
    class CustomList<T>
    {
        private T[] _items;
        private int _size;
        public CustomList() : this(0) { }

        public CustomList(int capacity)
        {
            _items = new T[capacity];
        }
        public T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_size) throw new ArgumentOutOfRangeException();
                return _items[index];
            }

            set
            {
                if ((uint)index >= (uint)_size) throw new ArgumentOutOfRangeException();
                _items[index] = value;
            }
        }
        public int Count => _size;
        public int Capacity => _items.Length;

        public void Add(T item)
        {
            if (_size == _items.Length)
                Grow(_size + 1);
            _items[_size] = item;
            _size++;
        }
        public void Grow(int minCap)
        {
            int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
            if (newCapacity < minCap) newCapacity = minCap;
            T[] newItems = new T[newCapacity];
            Console.WriteLine($"RESIZE: {Capacity,6} -> {newCapacity,-6}   (adding element #{_size + 1})");
            if (_size > 0)
            {
                Array.Copy(_items, newItems, _size);
            }
            _items = newItems;
        }

        public void Clear()
        {
            _size = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < _size)
                throw new ArgumentException("Target array too small", nameof(array));
            for (int i = 0; i < _size; i++)
            {
                array[arrayIndex + i] = _items[i];
            }
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (_size == _items.Length)
                Grow(_size + 1);
            for (int i = _size; i >= index; i--)
            {
                _items[i + 1] = _items[i];
            }
            _items[index] = item;
            _size++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                for (int i = index; i < Count; i++)
                {
                    _items[i] = _items[i + 1];
                }
                _size--;
                return true;
            }
            return false;
        }

    }
}
