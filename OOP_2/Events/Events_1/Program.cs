namespace Events_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(100);
            account.Notify += DisplayMessage;
            account.Put(20); //adding money
            Console.WriteLine($"Account balance: {account.Sum}");
            account.Take(70); //trying to take from balance
            Console.WriteLine($"Account balance: {account.Sum}");
            account.Take(180);
            Console.WriteLine($"Account balance: {account.Sum}");
        }

        static void DisplayMessage(string message) => Console.WriteLine(message);
    }
    class Account
    {
        public delegate void AccountHandler(string msg);
        public event AccountHandler? Notify;
        public int Sum { get; private set;}
        public Account(int sum) => Sum = sum;
        public void Put(int sum) 
        {
            Sum += sum;
            Notify?.Invoke($"Balance added: {sum}");
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum; ;
                Notify?.Invoke($"Taken from account: {sum}");
            }
            else 
            {
                Notify?.Invoke($"Not enough money. Balance left: {Sum}");
            }
        }
    }

}
