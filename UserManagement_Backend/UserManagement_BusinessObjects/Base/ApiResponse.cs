using System.Net;

namespace BusinessObjects.Base
{
    public class APIResponce
    {
        private object _result;
        private string _errorMessage;
        private HttpStatusCode _statusCode;

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public object Result
        {
            get { return _result; }
        }

        public APIResponce(object result, HttpStatusCode statusCode, string errorMessage)
        {
            _result = result;
            _statusCode = statusCode;
            _errorMessage = errorMessage;
        }
    }
}
