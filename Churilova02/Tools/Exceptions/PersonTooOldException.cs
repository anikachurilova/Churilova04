using System;

namespace Churilova02.Tools.Exceptions
{
    internal class PersonTooOldException : Exception
    {
        public PersonTooOldException() : base($" Entered birthdate is invalid. You are too old!")
        {

        }
    }
}
