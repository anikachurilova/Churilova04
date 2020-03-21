using System;


namespace Churilova02.Tools.Exceptions
{
    internal class PersonDontExistException : Exception
    {
        public PersonDontExistException() : base($" Entered birthdate is invalid. You don't exist yet!")
        {

        }
    }
}
