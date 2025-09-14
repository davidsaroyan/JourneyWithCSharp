using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await PrintAsync();
            Console.WriteLine("Main things");
            Console.ReadLine();
        }
        static void Print()
        {
            Thread.Sleep(3000); // testing sleep
            Console.WriteLine("Async Hello");
        }
        static async Task PrintAsync()
        {
            Console.WriteLine("Start of async method");
            await Task.Run(Print);
            Console.WriteLine("End of PrintAsync");
        }
    }
}
