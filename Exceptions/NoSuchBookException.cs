using System.Runtime.Serialization;

namespace CodingChallenge18June.Exceptions
{
    [Serializable]
    internal class NoSuchBookException : Exception
    {
        public NoSuchBookException()
        {
        }

        public NoSuchBookException(string? message) : base(message)
        {
        }

        public NoSuchBookException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoSuchBookException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}