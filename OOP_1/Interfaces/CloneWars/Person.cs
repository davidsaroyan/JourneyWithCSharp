using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWars
{
    internal class Person : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address HomeAddress { get; set; }
        public Person(int id, string name, Address homeAddress)
        {
            Id = id;
            Name = name;
            HomeAddress = homeAddress;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public Person DeepClone()
        {
            var clone = (Person)this.MemberwiseClone();
            clone.HomeAddress = new Address(HomeAddress.City, HomeAddress.Street);
            return clone;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Id: {Id}\nName: {Name}\nLocation: {HomeAddress.Street} street, {HomeAddress.City}\n");
        }
    }
}
