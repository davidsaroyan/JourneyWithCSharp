namespace Thread_Pool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(DoWork);
            Thread thread2 = new Thread(DoWork);

            thread1.Start("Thread 1");
            thread2.Start("Thread 2");

            ThreadPool.QueueUserWorkItem(DoWork, "Threadpool 1");
            ThreadPool.QueueUserWorkItem(DoWork, "Threadpool 2");

            Console.WriteLine("Main thread going on...");

            thread1.Join();
            thread2.Join();

            Console.WriteLine("All Threads have finished their work.");
            Console.ReadLine();
        }
        public static void DoWork(object threadName)
        {
            Console.WriteLine($"Thread '{threadName}' is Starting its work...");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread '{threadName}' has finished its work!");
        }
    }
}
