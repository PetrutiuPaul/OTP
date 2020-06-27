using System;

namespace OTP.Exceptions
{
    public class UserSecretException : Exception
    {
        public UserSecretException()
        {
        }

        public UserSecretException(string message) : base(message)
        {
        }

        public UserSecretException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
