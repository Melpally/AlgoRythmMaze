using System.Net;

namespace TopiTopi.Application.Exceptions
{
    public sealed class OperationFailedException : AppHandledException
    {
        public OperationFailedException() : base(HttpStatusCode.BadRequest) { }
        public OperationFailedException(string message) : base(message, HttpStatusCode.BadRequest) { }
    }
}
