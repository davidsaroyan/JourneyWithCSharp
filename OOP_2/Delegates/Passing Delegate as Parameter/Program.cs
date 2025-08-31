namespace Passing_Delegate_as_Parameter
{
    internal class Program
    {
        //passing methods as arguments
        static void Main(string[] args)
        {
            MathOperation operation = new MathOperation(Add);
            operation +=Multiply;
            Calculator(5,2,Add);
            Calculator(5,2,Multiply);
            Calculator(5,2,(a,b)=> a-b); //usable with lambda expressions
            Console.ReadLine();
        }
        public static void Calculator(int a, int b, MathOperation op)
        {
            int result = op(a, b);
            Console.WriteLine($"Result: {result}");
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
