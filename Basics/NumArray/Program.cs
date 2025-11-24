namespace NumArray
{
    //Read 5 integers, store in array, print sum, average, min, max, and sort ascending/descending.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 5 integers");
            int[] arr = new int[5];
            int sum = 0;
            int average = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < 5; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                sum += arr[i];
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }
            average = sum / arr.Length;
            Console.WriteLine($"Arrays sum: {sum}");
            Console.WriteLine($"Arrays average: {average}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++) 
                {
                    if ( arr[i] < arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted array (ascending)");
            for (int i = 0; i < arr.Length; i++) 
            {
                Console.Write(arr[i] + " ");
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Sorted array (descending)");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
