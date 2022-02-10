using System.Runtime.Serialization;

namespace Fantastic3D.DataManager
{
    [Serializable]
    public class IdMismatchException : Exception
    {
        public IdMismatchException()
        {
        }

        public IdMismatchException(string? message) : base(message)
        {
        }

        public IdMismatchException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IdMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}