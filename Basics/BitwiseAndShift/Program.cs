namespace BitwiseAndShift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nBinary representation: {Convert.ToString(num, 2)}");

            // Left shift by 1
            int leftShift = num << 1;
            // Right shift by 1
            int rightShift = num >> 1;

            Console.WriteLine($"\nLeft shift (num << 1): {leftShift}  => {Convert.ToString(leftShift, 2)}");
            Console.WriteLine($"Right shift (num >> 1): {rightShift}  => {Convert.ToString(rightShift, 2)}");

            Console.Write("\nEnter another integer for bitwise operations: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int andResult = num & num2;
            int orResult = num | num2;
            int xorResult = num ^ num2;

            Console.WriteLine($"\n{num} & {num2} = {andResult}  => {Convert.ToString(andResult, 2)}");
            Console.WriteLine($"{num} | {num2} = {orResult}  => {Convert.ToString(orResult, 2)}");
            Console.WriteLine($"{num} ^ {num2} = {xorResult}  => {Convert.ToString(xorResult, 2)}");
        }
    }
}
