using System;
using System.Runtime.Serialization;

namespace Fantastic3D.DataManager
{
    /// <summary>
    /// Represents errors that occurs when recording data through a DataManager.
    /// </summary>
    [Serializable]
    public class DataRecordException : Exception
    {
        public DataRecordException()
        {
        }

        public DataRecordException(string? message) : base(message)
        {
        }

        public DataRecordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DataRecordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}