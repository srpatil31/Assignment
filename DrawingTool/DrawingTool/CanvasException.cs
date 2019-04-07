using System;
using System.Runtime.Serialization;

namespace DrawingTool
{
    [Serializable]
    public class CanvasException : Exception
    {
        public CanvasException()
        {
        }

        public CanvasException(string message) : base(message)
        {
        }

        public CanvasException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CanvasException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}