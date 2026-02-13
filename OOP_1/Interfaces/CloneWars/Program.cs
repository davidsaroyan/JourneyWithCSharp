namespace CloneWars
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var original = new Person(12345, "David", new Address("Yerevan", "Kirkorian"));
            Console.WriteLine("Original:");
            original.PrintInfo();

            var shallow = (Person)original.Clone();
            shallow.HomeAddress.City = "London";               // change clone , original affected

            Console.WriteLine("After changing shallow clone's city, original now:");
            original.PrintInfo();   // shows London — proof of shared reference

            Console.WriteLine("Shallow clone itself:");
            shallow.PrintInfo();

            var deep = original.DeepClone();
            deep.HomeAddress.City = "Paris";                   // change deep, original unchanged

            Console.WriteLine("After changing deep clone's city, original still:");
            original.PrintInfo();

            Console.WriteLine("Deep clone itself:");
            deep.PrintInfo();

            Console.ReadLine();
        }
    }
}
