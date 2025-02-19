using System.Net;

namespace TopiTopi.Application.Exceptions
{
    public abstract class AppHandledException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        protected AppHandledException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        protected AppHandledException(string message, HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
