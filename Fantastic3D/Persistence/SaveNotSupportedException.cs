using System.Runtime.Serialization;

namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Exception raised when the handler can only load, but not save.
    /// </summary>
    [Serializable]
    internal class SaveNotSupportedException : Exception
    {
        public SaveNotSupportedException()
        {
        }

        public SaveNotSupportedException(string? message) : base(message)
        {
        }

        public SaveNotSupportedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SaveNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}