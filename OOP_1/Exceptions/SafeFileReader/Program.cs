namespace SafeFileReader
{
    internal class Program
    {
        static void FileReader()
        {
            Console.WriteLine("Give me path from were I can read.");
            var path = Console.ReadLine()?.Trim();
            string text = null;
            try
            {
                text = File.ReadAllText(path);
                Console.WriteLine("===Content===\n");
                Console.WriteLine(text);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Invalid Path, file not found.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("IO exception, try again.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("I don't have access for this file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected explosion: {ex.GetType().Name} – {ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                FileReader();
                Console.WriteLine("\nAnother file? (y/n)");
                if (Console.ReadLine()?.Trim().ToLower() != "y") break;
            }
        }
    }
}
