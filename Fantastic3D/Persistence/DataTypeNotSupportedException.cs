using System.Runtime.Serialization;

namespace Fantastic3D.Persistence
{
    [Serializable]
    internal class DataTypeNotSupportedException : Exception
    {
        /// <summary>
        /// Exception for a type of data that isn't supported by the handler.
        /// </summary>
        public DataTypeNotSupportedException()
        {
        }

        public DataTypeNotSupportedException(string? message) : base(message)
        {
        }

        public DataTypeNotSupportedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DataTypeNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}