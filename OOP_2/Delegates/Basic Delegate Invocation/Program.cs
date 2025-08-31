namespace Basic_Delegate_Invocation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MathOperation add = new MathOperation(Add);
            MathOperation multiply = new MathOperation(Multiply);
            int x = add.Invoke(2,5);
            int y = multiply.Invoke(2,5);
            Console.WriteLine("Values with same delegate but different methods.");
            Console.WriteLine($"With method Add: {x}");
            Console.WriteLine($"With method Multiply: {y}");
            Console.ReadLine();
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

    }
    delegate int MathOperation(int x, int y);
}
