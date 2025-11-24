namespace TxtReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me path to your txt file");
            string path = Console.ReadLine();
            string text = File.ReadAllText(path);
            Console.WriteLine("This is your text: \n");
            Console.WriteLine(text);
            var creationTime = File.GetCreationTime(path);
            Console.WriteLine($"You made this in {creationTime}");
        }
    }
}
