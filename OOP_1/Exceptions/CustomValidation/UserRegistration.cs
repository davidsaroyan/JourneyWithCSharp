using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomValidation
{
    internal class UserRegistration
    {
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRegistration( string email, int age, string password)
        {
            Age = age;
            Email = email;
            Password = password;
        }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@") || !Email.Contains("."))
            {
                throw new InvalidEmailFormatException("Email must contain @ and a domain (example@site.com)");
            }
            if (Age < 13 || Age > 120)
            {
                throw new AgeOutOfRangeException($"Age must be between 13 and 120. You put {Age}.");
            }
            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 8)
            {
                throw new WeakPasswordException("Password must be at least 8 characters long.");
            }
            if (!Password.Any(char.IsUpper))
            {
                throw new WeakPasswordException("Password must contain at least one uppercase letter.");
            }
            if (!Password.Any(char.IsDigit))
            {
                throw new WeakPasswordException("Password must contain at least one digit.");
            }
        }
    }
}
