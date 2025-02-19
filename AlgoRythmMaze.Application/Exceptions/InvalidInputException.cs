using System.Net;

namespace TopiTopi.Application.Exceptions
{
    public sealed class InvalidInputException : AppHandledException
    {
        public InvalidInputException() : base(HttpStatusCode.BadRequest) { }
        public InvalidInputException(string message) : base(message, HttpStatusCode.BadRequest) { }
    }
}
