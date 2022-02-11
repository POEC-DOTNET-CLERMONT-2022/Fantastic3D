using System;
using System.Runtime.Serialization;

namespace Fantastic3D.DataManager
{
    /// <summary>
    /// Represents errors that occurs when retrieving data through a DataManager.
    /// </summary>
    [Serializable]
    public class DataRetrieveException : Exception
    {
        public DataRetrieveException()
        {
        }

        public DataRetrieveException(string? message) : base(message)
        {
        }

        public DataRetrieveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DataRetrieveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}