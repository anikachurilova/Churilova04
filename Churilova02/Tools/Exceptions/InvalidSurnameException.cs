using System;


namespace Churilova02.Tools.Exceptions
{
    internal class InvalidSurnameException : Exception
    {
        public InvalidSurnameException(string surname) : base($" Entered surname is invalid. You must use a-z letters of both registers.")
        {

        }
    }
}

