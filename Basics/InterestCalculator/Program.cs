namespace InterestCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Starting amount of money, Rate, and time (years)");
            double start = double.Parse(Console.ReadLine());
            double rate = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());
            double simpleInterest = (start * rate * time) / 100;
            double afterCI = start * Math.Pow((1 + rate / 100), time);
            double compoundInterest = afterCI - start;
            Console.WriteLine($"You will earn (simple interest): {simpleInterest:F3}$");
            Console.WriteLine($"You will earn (compound interest): {compoundInterest:F3}$");
            Console.ReadLine();
        }
    }
}
