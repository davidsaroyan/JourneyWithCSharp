namespace ValueVsReferenceTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We will see difference between value types and reference types");
            Console.WriteLine("Lets create int a = 10 and copy it");
            int a = 10;
            int b = a;
            Console.WriteLine($"b = {b}");
            a = 15;
            Console.WriteLine("Now lets change - a, and see what happens to - b");
            Console.WriteLine($"a = {a}, b = {b}");
            int[] arr1 = { 1, 2, 3, 6, 5 };
            Console.WriteLine();
            Console.WriteLine("Now lets create an array 1");
            for (int i = 0; i < arr1.Length; i++) 
            {
                Console.Write(arr1[i] + " ");
            }
            Console.WriteLine();
            int[] arr2 = arr1;
            Console.WriteLine("Lets copy it to another array");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("And lets see what happens after we change array 1 numbers");
            Console.Write("Array one: ");
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = 0;
                Console.Write(arr1[i] + " ");
            }
            Console.WriteLine();
            Console.Write("Array two: ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
