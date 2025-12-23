using System.Buffers;

namespace BankAccountSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount b1 = new BankAccount("David", 5000);
            BankAccount b2 = new BankAccount("Jane", 7500);
            b1.Withdraw(7000);
            b2.Deposit(2100);
            b1.Withdraw(1200);
            Console.ReadLine();
        }
    }
    public class BankAccount
    {
        private string _owner { get; set; }
        private decimal _balance { get; set; }
        public BankAccount(string owner, decimal balance)
        {
            _owner = owner;
            _balance = balance;
        }
        public void Deposit(decimal amount)
        {
            _balance += amount;
            Console.WriteLine($"Succesfull deposit of ${amount} to {_owner}'s balance");
            Console.WriteLine($"Current balance: ${_balance}\n");
        }
        public void Withdraw(decimal amount)
        {
            if (_balance - amount >= 0)
            {
                _balance -= amount;
                Console.WriteLine($"Succesfull withdrawl of ${amount} from {_owner}'s balance");
                Console.WriteLine($"Current balance: ${_balance}\n");
            }
            else
            {
                Console.WriteLine("Not enough balance");
                Console.WriteLine($"Current balance: ${_balance}\n");
            }
        }
    }
}
