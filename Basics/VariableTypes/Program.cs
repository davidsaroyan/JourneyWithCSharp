namespace VariableTypes
{
    //implicitly typed variables using var. Print their inferred types with .GetType().
    internal class Program
    {
        static void Main(string[] args)
        {
            var myVar = 15;
            var myVar1 = 5.5f;
            var myVar2 = 17.5m;
            var myVar3 = 'a';
            var myVar4 = "Hi from Var";
            Console.WriteLine($"Var: {myVar}, type: {myVar.GetType()}");
            Console.WriteLine($"Var: {myVar1}, type: {myVar1.GetType()}");
            Console.WriteLine($"Var: {myVar2}, type: {myVar2.GetType()}");
            Console.WriteLine($"Var: {myVar3}, type: {myVar3.GetType()}");
            Console.WriteLine($"Var: {myVar4}, type: {myVar4.GetType()}");
            Console.ReadLine();
        }
    }
}
