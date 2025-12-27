using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSystem;

namespace ZooSystem
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract void MakeSound();
        public virtual void Move()
        {
            Console.WriteLine($"{Name} moves in a generic way");
        }
        public void Info()
        {
            Console.WriteLine($"{Name} is general Animal");
        }
    }
    class Dog : Animal,  IPet
    {
        public string Breed { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
        public new void Info()
        {
            Console.WriteLine($"{Name} is a Dog of breed {Breed}");
        }
        public void play()
        {
            Console.WriteLine($"{Name} is playing happily.");
        }
    }
    class Bulldog : Dog
    {
        public override void Move()
        {
            Console.WriteLine($"{Name} walks slowly with heavy steps");
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} grumbles and says: Woof!");
        }
        public new void Info()
        {
            Console.WriteLine($"{Name} is tough Bulldog.");
        }
    }
    class Cat : Animal,IPet
    {
        public bool IsIndoor { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
        public new void Info()
        {
            Console.WriteLine($"{Name} is a {(IsIndoor ? "house" : "street")} cat");
        }
        public void play()
        {
            Console.WriteLine($"{Name} is playing happily.");
        }
    }
    class Siamese : Cat
    {
        public override void Move()
        {
            Console.WriteLine($"{Name} walks gracefully lika a dancer");
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} purrs softly.");
        }
        public new void Info()
        {
            Console.WriteLine($"{Name} is an elegant Siamese cat.");
        }
    }
    class Bird : Animal , IFlyable
    {
        public bool CanFly { get; set; }
        public override void MakeSound()
        {
            Console.WriteLine("Tweet!");
        }
        public override void Move()
        {
            Console.WriteLine($"{Name} {(CanFly ? "flies" : "walks")} around.");
        }
        public new void Info()
        {
            Console.WriteLine($"{Name} is a bird.");
        }

        public void Fly()
        {
            if (CanFly) 
            {
                Console.WriteLine($"{Name} flaps and flies");
            }
        }
    }
    class Parrot : Bird
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} mimics: Hello!");
        }
        public new void Info()
        {
            Console.WriteLine($"{Name} is a talking Parrot.");
        }
    }
}
