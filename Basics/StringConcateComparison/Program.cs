using System.Diagnostics;
using System.Text;

namespace StringConcateComparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //String Immutability, Interning, StringBuilder
            //Concatenate a string 100,000 times using both normal string concatenation and StringBuilder.
            //Measure performance using Stopwatch.
            string st = "Hello";
            DateTime dateTime = DateTime.Now;
            for (int i = 0; i < 100000; i++) {
                st += "Hello";            
            }
            var timeSpan = DateTime.Now - dateTime;
            Console.WriteLine($"Time with simple concat: {timeSpan}");
            StringBuilder stringBuilder = new StringBuilder();
            dateTime = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                stringBuilder.Append("Hello");
            }
            timeSpan = DateTime.Now - dateTime;
            Console.WriteLine($"Time with String Builder: {timeSpan}");
        }
    }
}
