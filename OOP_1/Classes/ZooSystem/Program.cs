using System.Collections;
using System.Collections.Concurrent;

namespace ZooSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo<Animal> zoo = new Zoo<Animal>();
            Dog dog = new Dog() { Name = "Rex", Age = 2, Breed = "Shepherd" };
            Bulldog bullDog = new Bulldog() { Name = "Cookie", Age = 3, Breed = "French Bulldog"};
            Cat cat = new Cat() { Name= "Princces", Age = 4, IsIndoor = true};
            Siamese siameseCat = new Siamese() { Name = "Ariel", Age = 1, IsIndoor = true };
            Bird bird = new Bird() { Name = "Baldy", Age = 2,  CanFly = true };
            Parrot parrot = new Parrot() { Name = "Perry", Age = 1, CanFly = true };
            zoo.Add(dog);
            zoo.Add(bullDog);
            zoo.Add(cat);
            zoo.Add(siameseCat);
            zoo.Add(bird);
            zoo.Add(parrot);
            Console.WriteLine("-----AllSounds-------");
            zoo.MakeAllSounds();
            Console.WriteLine("-----AllMoves-------");
            zoo.MoveAllAnimals();
            Console.WriteLine("-----AllInfos-------");
            zoo.ShowAnimalInfos();
            Console.WriteLine("---Let pets play----");
            zoo.PlayWithPets();
            Console.WriteLine("---Let birds fly");
            zoo.LetBirdsFly();
            Console.WriteLine("------Polymorphism------");
            for (int i = 0; i < zoo.Count; i++) 
            {
                if (zoo[i] is Bulldog a) 
                {
                    a.Info();
                }
                if (zoo[i] is Siamese b)
                {
                    b.Info();
                }
                if (zoo[i] is Parrot c)
                {
                    c.Info();
                }
            }
            Console.ReadLine();

        }
    }
    public interface IPet
    {
        public abstract void play();
    }
    public interface IFlyable
    {
        public abstract void Fly();
    }
    public class Zoo<T> : IList<Animal> where T : Animal
    {
        #region IListImplementation    
        public T this[int index]
        {
            get => (T)animals[index];
            set => animals[index] = value;
        }
        private List<Animal> animals = new List<Animal>();
        Animal IList<Animal>.this[int index] { get => animals[index]; set => animals[index] = value; }

        public int Count => animals.Count;

        public bool IsReadOnly => false;

        public void Clear()
        {
            animals.Clear();
        }

        public void CopyTo(Animal[] array, int arrayIndex)
        {
            animals.CopyTo(array, arrayIndex);
        }

        public IEnumerator GetEnumerator()
        {
            return animals.GetEnumerator();
        }

        public void RemoveAt(int index)
        {
            animals.RemoveAt(index);
        }
        public void Add(Animal item)
        {
            animals.Add(item);
        }
        void ICollection<Animal>.Add(Animal item)
        {
            animals.Add(item);
        }

        bool ICollection<Animal>.Contains(Animal item)
        {
            return animals.Contains(item);
        }

        IEnumerator<Animal> IEnumerable<Animal>.GetEnumerator()
        {
            return animals.GetEnumerator();
        }

        int IList<Animal>.IndexOf(Animal item)
        {
            return animals.IndexOf(item);
        }

        void IList<Animal>.Insert(int index, Animal item)
        {
            animals.Insert(index, item);
        }

        bool ICollection<Animal>.Remove(Animal item)
        {
            return animals.Remove(item);
        }
        #endregion
        #region ExtraMethods
        public void MakeAllSounds()
        {
            for (int i = 0; i < animals.Count; i++)
            {
                animals[i].MakeSound();
            }
        }
        public void MoveAllAnimals()
        {
            for (int i = 0; i < animals.Count; i++)
            {
                animals[i].Move();
            }
        }
        public void ShowAnimalInfos()
        {
            for (int i = 0; i < animals.Count; i++)
            {
                animals[i].Info();
            }
        }
        public void PlayWithPets()
        {
            for (int i = 0; i < animals.Count; i++)
            {
                if(animals[i] is IPet a)
                {
                    a.play();
                } 
            }
        }
        public void LetBirdsFly()
        {
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i] is IFlyable a)
                {
                    a.Fly();
                }
            }
        }
        #endregion
    }

}
