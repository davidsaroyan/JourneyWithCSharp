using System;

namespace NotificationService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose notification type:");
            Console.WriteLine("1 - Email");
            Console.WriteLine("2 - SMS");
            Console.WriteLine("3 - Push");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            INotifier notifier = choice switch
            {
                1 => new EmailNotifier(),
                2 => new SmsNotifier(),
                3 => new PushNotifier(),
                _ => null
            };

            if (notifier == null)
            {
                Console.WriteLine("Input Error.");
                return;
            }

            Console.Write("Enter recipient: ");
            string recipient = Console.ReadLine();

            Console.Write("Enter message: ");
            string message = Console.ReadLine();

            var manager = new NotificationManager(notifier);
            manager.Send(message, recipient);

            Console.ReadKey();
        }
    }

    public interface INotifier
    {
        void Send(string message, string recipient);
    }

    public class EmailNotifier : INotifier
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine($"[EMAIL] To {recipient}: {message}");
        }
    }

    public class SmsNotifier : INotifier
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine($"[SMS] To {recipient}: {message}");
        }
    }

    public class PushNotifier : INotifier
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine($"[PUSH] To {recipient}: {message}");
        }
    }

    public class NotificationManager
    {
        private readonly INotifier _notifier;

        public NotificationManager(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Send(string message, string recipient)
        {
            _notifier.Send(message, recipient);
        }
    }
}