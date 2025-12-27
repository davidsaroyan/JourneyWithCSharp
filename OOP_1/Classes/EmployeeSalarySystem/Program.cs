using System;
using System.Collections.Generic;

namespace EmployeeSalarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new FullTimeEmployee(1000, "Jane", 40),
                new PartTimeEmployee(1001, "Kevin", 40),
                new Intern(1002, "David", 40)
            };

            foreach (var employee in employees)
            {
                employee.ShowInfo();
            }

            Console.ReadLine();
        }
    }

    public abstract class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public int WorkedHours { get; }

        protected Employee(int id, string name, int workedHours)
        {
            Id = id;
            Name = name;
            WorkedHours = workedHours;
        }

        public abstract double CalculateSalary();

        public void ShowInfo()
        {
            Console.WriteLine(
                $"Name: {Name}, ID: {Id}, Salary: {CalculateSalary()}, Type: {GetType().Name}"
            );
        }
    }

    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(int id, string name, int workedHours)
            : base(id, name, workedHours)
        {
        }

        public override double CalculateSalary()
        {
            return WorkedHours * 12;
        }
    }

    public class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(int id, string name, int workedHours)
            : base(id, name, workedHours)
        {
        }

        public override double CalculateSalary()
        {
            return WorkedHours * 10;
        }
    }

    public class Intern : Employee
    {
        public Intern(int id, string name, int workedHours)
            : base(id, name, workedHours)
        {
        }

        public override double CalculateSalary()
        {
            return WorkedHours * 6;
        }
    }
}