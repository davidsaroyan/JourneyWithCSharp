namespace TypeConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer number");
            string input = Console.ReadLine();
            int iNum = Convert.ToInt32(input);
            Console.WriteLine("Enter an float number");
            input = Console.ReadLine();
            float fNum = Convert.ToSingle(input);
            Console.WriteLine("Enter an double number");
            input = Console.ReadLine();
            double dNum = Convert.ToDouble(input);
            Console.WriteLine($"Int: {iNum}");
            Console.WriteLine($"Float: {fNum}");
            Console.WriteLine($"Double: {dNum}");
            Console.ReadLine();
        }
    }
}
