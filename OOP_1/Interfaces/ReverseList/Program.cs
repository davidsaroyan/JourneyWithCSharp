using System.Collections;

namespace ReverseList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReversedList<int> nums = new ReversedList<int>([1,2,3,4,5]);
            Console.Write("Reversed: ");;
            foreach (var item in nums)
            {
                Console.Write(item+ " ");
            }
            Console.ReadLine();
        }
    }
    public class ReversedList<T> : IEnumerable<T>
    {
        private readonly List<T> _list;
        public ReversedList(IEnumerable<T> list)
        {
            _list = new List<T>(list);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _list.Count - 1; i >= 0; i--)
            {
                yield return _list[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
