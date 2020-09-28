using System;
using System.Runtime.Serialization;

namespace service.server.Controllers
{
    [Serializable]
    internal class UnauthException : Exception
    {
        public UnauthException()
        {
        }

        public UnauthException(string message) : base(message)
        {
        }

        public UnauthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}