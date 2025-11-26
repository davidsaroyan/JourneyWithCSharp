namespace DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("type number from 1-7, and see its day of the week");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.WriteLine($"{Weekdays.monday} is a weekday");
                    break;
                case 2:
                    Console.WriteLine($"{Weekdays.tuesday} is a weekday");
                    break;
                case 3:
                    Console.WriteLine($"{Weekdays.wednesday} is a weekday");
                    break;
                case 4:
                    Console.WriteLine($"{Weekdays.thursday} is a weekday");
                    break;
                case 5:
                    Console.WriteLine($"{Weekdays.friday} is a weekday");
                    break;
                case 6:
                    Console.WriteLine($"{Weekdays.saturday} is a WEEKEND!!");
                    break;
                case 7:
                    Console.WriteLine($"{Weekdays.sunday} is a WEEKEND!!");
                    break;
                default:
                    Console.WriteLine("I said from 1 to 7");
                    break;
            }
        }
        enum Weekdays
        {
            monday = 1,
            tuesday = 2,
            wednesday = 3,
            thursday = 4,
            friday = 5,
            saturday = 6,
            sunday = 7,
        }
    }
}
