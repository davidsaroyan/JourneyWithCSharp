namespace DivisionByZero
{
    class DivisionRetryFailedException : Exception
    {
        public DivisionRetryFailedException(string message) : base(message) { }
    }
    internal class Program
    {
        static int SafeDivide(int a, int b, int maxRetries = 3)
        {
            int attempts = 0;

            while (attempts < maxRetries)
            {
                try
                {
                    return a / b;           
                }
                catch (DivideByZeroException)
                {
                    attempts++;
                    Console.WriteLine($"Attempt {attempts}/{maxRetries}: You can't divide by zero, Enter new b:");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out b) || b == 0)
                    {
                        Console.WriteLine("You can't divide by zero, Enter new b:");
                        continue; 
                    }
                }
            }

            throw new DivisionRetryFailedException(
                $"Failed to divide after {maxRetries} attempts. Last b was {b}.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Safe Division with Retries\n");

            try
            {
                Console.Write("Enter a: ");
                int a = int.Parse(Console.ReadLine());

                Console.Write("Enter b: ");
                int b = int.Parse(Console.ReadLine());

                int result = SafeDivide(a, b);
                Console.WriteLine($"\nResult: {a} / {b} = {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("You typed Something wrong");
            }
            catch (DivisionRetryFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected disaster: {ex.Message}");
            }
        }
    }
}
