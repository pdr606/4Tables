using System.Net;

namespace _4Tables.Domain.Base.Common
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public Error(HttpStatusCode httpStatusCode, string message)
        {
            StatusCode = (int)httpStatusCode;
            Message = message;
        }

        public Error(string message)
        {
            Message = message;
        }
    }
}
