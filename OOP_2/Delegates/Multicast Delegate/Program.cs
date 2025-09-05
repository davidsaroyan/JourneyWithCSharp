namespace Multicast_Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Printer p = new Printer(PrintUpperCase);
            p += PrintLowerCase;
            p.Invoke("Same message with different methods");
            Console.WriteLine("\nNow lets use GetInvocationList\n");
            var methodList = p.GetInvocationList();
            foreach (var method in methodList) 
            {
                method.DynamicInvoke("Message with Dynamic Invoke");
            }
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
