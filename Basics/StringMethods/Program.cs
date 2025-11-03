namespace StringMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ask for a full name.
            //Output first and last names separately, initials,
            //uppercase/lowercase, whether it contains “a”, and its length.
            Console.WriteLine("Whats your name and surname?");
            string[] fullName = Console.ReadLine().Split(" ");
            string name = fullName[0];
            string surname = fullName[1];
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Initials: {name[0]}. {surname[0]}.");
            Console.WriteLine($"Uppercase: {name.ToUpper()}");
            Console.WriteLine($"           {surname.ToUpper()}");
            Console.WriteLine($"Lowercase: {name.ToLower()}");
            Console.WriteLine($"           {surname.ToLower()}");
            if (name.Contains('a') && surname.Contains('a'))
            {
                Console.WriteLine("Your full name contains letter 'a' ");
            }
            Console.WriteLine($"Length of name: {name.Length}");
            Console.WriteLine($"Length of surname: {surname.Length}");
            Console.ReadLine();
        }
    }
}
