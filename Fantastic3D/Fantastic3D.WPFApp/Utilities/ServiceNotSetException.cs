using System;
using System.Runtime.Serialization;

namespace Fantastic3D.GUI.Utilities
{
    [Serializable]
    internal class ServiceNotSetException : Exception
    {
        public override string Message => "No suitable service was set for this type.";
        public ServiceNotSetException()
        {
        }

        public ServiceNotSetException(string? message) : base(message)
        {
        }

        public ServiceNotSetException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ServiceNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}