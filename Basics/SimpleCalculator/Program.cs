namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Here is a simple calculator that support different num types");
            Console.WriteLine("What do you want to use? (i: int, d: double, c: decimal)");
            char type = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Now type 2 numbers");
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            if (type == 'i')
            {
                int a = Convert.ToInt32(input1);
                int b = Convert.ToInt32(input2);
                Console.WriteLine($"Sum: {a+b}");
                Console.WriteLine($"Sub: {a-b}");
                Console.WriteLine($"Multiply: {a*b}");
                Console.WriteLine($"Divide: {a+b}");
            }
            else if(type == 'd')
            {
                double a = Convert.ToInt32(input1);
                double b = Convert.ToInt32(input2);
                Console.WriteLine($"Sum: {a + b}");
                Console.WriteLine($"Sub: {a - b}");
                Console.WriteLine($"Multiply: {a * b}");
                Console.WriteLine($"Divide: {a + b}");
            }
            else if (type == 'c')
            {
                decimal a = Convert.ToInt32(input1);
                decimal b = Convert.ToInt32(input2);
                Console.WriteLine($"Sum: {a + b}");
                Console.WriteLine($"Sub: {a - b}");
                Console.WriteLine($"Multiply: {a * b}");
                Console.WriteLine($"Divide: {a + b}");
            }
        }
    }
}
