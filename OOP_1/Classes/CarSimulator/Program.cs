using System.Net.Http.Headers;

namespace CarSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("BMW", 20);
            car.Drive();
            car.Drive();
            car.Drive();
            car.Refuel(30);
            car.Refuel(14);
            car.Refuel(40);
            car.Drive();
            Console.ReadLine();
        }
    }
    public class Car
    {
        public string Name { get; set; }
        private double _fuel { get; set; }
        public Car(string name, double fuel)
        {
            Name = name;
            _fuel = fuel;
        }
        public void Drive()
        {
            if (_fuel - 10 >= 0)
            {
                _fuel -= 10;
                Console.WriteLine($"{Name} is driving Around...\n");
            }
            else Console.WriteLine("You are out of fuel:( \n");
        }
        public void Refuel(double amount)
        {
            Console.WriteLine("Trying to refuel..");
            if (_fuel + amount <= 60)
            {
                _fuel += amount;
                Console.WriteLine($"Fuel level: {(_fuel*100 / 60):F2}%\n");
            }
            else
            {
                Console.WriteLine("Your tank cant refuel that much");
                Console.WriteLine($"Fuel level: {(_fuel *100 / 60):F2}%\n");
            }
        }
    }
}
