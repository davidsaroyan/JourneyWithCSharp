using System.Security.Cryptography.X509Certificates;

namespace AnimalSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAnimal dog = new Dog();
            IAnimal bird = new Bird();
            dog.MakeSound();
            dog.Move();
            bird.MakeSound();
            bird.Move();
            Console.ReadLine();
        }
    }
    public interface IAnimal
    {
        public void MakeSound();
        public void Move();
    }
    public class Dog : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Doggy barks! WOOF");
        }

        public void Move()
        {
            Console.WriteLine("Doggy walks on 4 feet");
        }
    }
    public class Bird : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Birdy beeps! TWEET");
        }

        public void Move()
        {
            Console.WriteLine("Birdy flies");
        }
    }
}
