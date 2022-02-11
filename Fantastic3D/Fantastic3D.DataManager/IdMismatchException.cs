using System.Runtime.Serialization;

namespace Fantastic3D.DataManager
{
    /// <summary>
    /// Represents errors that occurs when an operation is attempted in a DataManager when providing two distinct IDs for the same Manageable Object.
    /// </summary>
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