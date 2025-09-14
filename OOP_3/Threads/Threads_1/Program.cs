namespace Threads_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Number od Cores: {Environment.ProcessorCount}");
            Console.WriteLine($"Current Managed Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Thread thread = new Thread(() => PrintA(50));
            Thread thread1 = new Thread(() => PrintB(50));
            thread.Start();
            thread1.Start();
            Console.ReadLine();
        }
        public static void PrintA(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(40);
                Console.Write(" A ");
            }
        }
        public static void PrintB(int n)
        {
            for(int i = 0;i < n; i++)
            {
                Thread.Sleep(40);
                Console.Write(" B ");
            }
        }
    }
}
