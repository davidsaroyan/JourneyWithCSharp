using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CustomValidation
{
    public class RegistrationException : Exception
    {
        public RegistrationException(string message) : base(message) { }
    }
    public class InvalidEmailFormatException : RegistrationException
    {
        public InvalidEmailFormatException(string message) : base(message) { }
    }

    public class AgeOutOfRangeException : RegistrationException
    {
        public AgeOutOfRangeException(string message) : base(message) { }
    }

    public class WeakPasswordException : RegistrationException
    {
        public WeakPasswordException(string message) : base(message) { }
    }
}
