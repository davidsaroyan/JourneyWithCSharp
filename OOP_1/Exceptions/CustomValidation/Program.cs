namespace CustomValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var usersToTest = new[]
            {
            new UserRegistration("valid@email.com", 25, "StrongP@ss1"),          
            new UserRegistration("bad-email", 20, "Abcd1234"),                    
            new UserRegistration("test@ok.com", 10, "ValidPass123"),             
            new UserRegistration("another@ok.com", 30, "weak"),                   
            new UserRegistration("fail@here.com", 150, "Short1")                  
            };

            foreach (var user in usersToTest)
            {
                Console.WriteLine($"\nTesting: {user.Email}, Age: {user.Age}, Pass: {user.Password}");

                try
                {
                    user.Validate();
                    Console.WriteLine("Registration OK");
                }
                catch (InvalidEmailFormatException ex)
                {
                    Console.WriteLine($"Email error: {ex.Message}");
                }
                catch (AgeOutOfRangeException ex)
                {
                    Console.WriteLine($"Age error: {ex.Message}");
                }
                catch (WeakPasswordException ex)
                {
                    Console.WriteLine($"Password error: {ex.Message}");
                }
                catch (RegistrationException ex)
                {
                    Console.WriteLine($"General registration fail: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something really bad happened: {ex.GetType().Name} – {ex.Message}");
                }
            }
        }
    }
}


