namespace Grading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your Grade(0-100)");
            int grade = int.Parse(Console.ReadLine());
            string result = ""; 
            Console.WriteLine();
            if (grade >= 0 && grade < 40) result = "Bad";
            else if (grade >= 40 && grade < 60) result = "Average";
            else if (grade >= 60 && grade < 90) result = "Good";
            else if (grade >= 90 && grade <= 100) result = "Excellent";
            else result = "Dumb";
            Console.WriteLine($"You are {result} student :)");
        }
    }
}
