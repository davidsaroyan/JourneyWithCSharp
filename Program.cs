using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace ConsoleApp31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

    }
    class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    class CarDTO
    {
        public int Id { get; set; }
        public string ShortDesc { get; set; }
    }
    static class Mapper<TSource, TDestination> 
    {
        static TDestination Map(TSource source,Func<TSource,TDestination> func) 
        {

        }

    }
}
