namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int x = random.Next(1, 100);
            Console.WriteLine("Guess the number from 1-100");
            int guess = int.Parse(Console.ReadLine());
            while (guess != x)
            {
                if (guess > x )
                {
                    Console.WriteLine($"{guess} is higher than my number");
                    guess = int.Parse(Console.ReadLine());
                }else if (guess < x) 
                {
                    Console.WriteLine($"{guess} is lower than my number");
                    guess = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Congrats you guessed my number");
        }
    }
}