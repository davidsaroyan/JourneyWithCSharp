namespace Threads_OddAndEven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread threadEven = new Thread(()=>PrintEvenNumbers(20));
            Thread threadOdd = new Thread(()=>PrintOddNumbers(20));
            threadEven.Start();
            threadOdd.Start();  //Threads start their work
            threadEven.Join(); 
            threadOdd.Join();    //Main waits until threads finish their work 
            Console.WriteLine("Main thread finished.");
            Console.ReadLine();
        }
        static void PrintEvenNumbers(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(500);
                if (i % 2 == 0)
                {
                    Console.WriteLine($"Even: {i}");
                }
            }
        }
        static void PrintOddNumbers(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(500);
                if (i % 2 != 0)
                {
                    Console.WriteLine($"Odd: {i}");
                }
            }
        }
    }
}
