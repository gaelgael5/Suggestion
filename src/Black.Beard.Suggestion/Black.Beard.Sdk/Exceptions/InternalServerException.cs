using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Exceptions
{


    [Serializable]
    public class InternalServerException : Exception
    {
        public InternalServerException() { }
        public InternalServerException(string message) : base(message) { }
        public InternalServerException(string message, Exception inner) : base(message, inner) { }
        protected InternalServerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
