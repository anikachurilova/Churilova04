using System;


namespace Churilova02.Tools.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($" You entered invalid email: {email}")
        {

        }
    }
}
