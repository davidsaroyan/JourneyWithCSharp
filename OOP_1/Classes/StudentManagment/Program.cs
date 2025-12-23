using System.Security.Cryptography.X509Certificates;

namespace StudentManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student(1000,"David",65);
            Student st1 = new Student(1001,"John",30);
            Student st2 = new Student(1002,"Jane",90);
            st.DisplayInfo();
            Console.WriteLine($"Exam passed: {st.IsPassed()}\n");
            st1.DisplayInfo();
            Console.WriteLine($"Exam passed: {st1.IsPassed()}\n");
            st2.DisplayInfo();
            Console.WriteLine($"Exam passed: {st2.IsPassed()}\n");
            Console.ReadLine();
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public Student(int id, string name, int grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
        public void DisplayInfo()
        {
            System.Console.WriteLine($"Student Name: {Name},\nGrade: {Grade},\nID: {Id}");
        }
        public bool IsPassed()
        {
            if(Grade>=40) return true;
            else return false;
        }
    }
}
