namespace EvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type number");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0) Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Evens until your number");
            Console.ReadLine();
        }
    }
}
