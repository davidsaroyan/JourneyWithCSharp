namespace FibonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            long fib1 = 0, fib2 = 1, next;

            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    Console.Write(fib1);
                }
                else if (i == 2)
                {
                    Console.Write(" " + fib2);
                }
                else
                {
                    next = fib1 + fib2;
                    Console.Write(" " + next);
                    fib1 = fib2;
                    fib2 = next;
                }
            }
        }
    }
}
