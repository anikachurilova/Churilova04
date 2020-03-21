using System;


namespace Churilova02.Tools.Exceptions
{
    internal class InvalidNameException : Exception
    {
        public InvalidNameException(string name) : base($" Entered name is invalid. You must use a-z letters of both registers.")
        {

        }
    }
}
