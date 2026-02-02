namespace Sortable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 9, 3, 45 ,6,-5};
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            BubbleSort bSort = new BubbleSort();
            SelectionSort selSort = new SelectionSort();
            //bSort.Sort(arr);
            selSort.Sort(arr);
            for (int i = 0; i < arr.Length; i++) 
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
    public interface ISortable
    {
        void Sort(int[] arr);
    }
    class BubbleSort : ISortable
    {
        public void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
    class SelectionSort : ISortable
    {
        public void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }
    }
}
