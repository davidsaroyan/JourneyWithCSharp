namespace PolindromeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type anything i'll check if its polindrome");
            string text = Console.ReadLine();
            text = text.Replace(" ", "");
            string reversed = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversed = reversed + text[i];
            }
            if (string.Equals(text, reversed, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Your text is polindrome :)");
            }
            else
            {
                Console.WriteLine("Your text is NOT polindrome :(");
            }
        }
    }
}