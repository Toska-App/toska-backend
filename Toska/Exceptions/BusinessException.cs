namespace Toska.Exceptions
{
    public class BusinessException : Exception
    {
        public int StatusCode { get; }
        public string ErrorCode { get; }
        public string UserMessage { get; }


        protected BusinessException(
            string message,
            string userMessage,
            int statusCode = StatusCodes.Status400BadRequest,
            string? errorCode = null
        ) : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode ?? GetType().Name;
            UserMessage = userMessage;
        }
    }
}
