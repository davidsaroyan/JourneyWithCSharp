namespace Multicast_Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Printer p = new Printer(PrintUpperCase);
            p += PrintLowerCase;
            p.Invoke("Same message with different methods");
            Console.ReadLine();
        }
        public static void PrintUpperCase(string msg)
        {
            Console.WriteLine(msg.ToUpper());
        }
        public static void PrintLowerCase(string msg)
        {
            Console.WriteLine(msg.ToLower());
        }
    }
    delegate void Printer(string msg);
}
