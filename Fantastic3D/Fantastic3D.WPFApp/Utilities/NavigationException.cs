using System;
using System.Runtime.Serialization;

namespace Fantastic3D.GUI.Utilities
{
    [Serializable]
    public class NavigationException : Exception
    {
        public override string Message => "Couldn't navigate through view as expected.";
        public NavigationException()
        {
        }

        public NavigationException(string? message) : base(message)
        {
        }

        public NavigationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NavigationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}