namespace Trovantenato.Web.Common.Exceptions
{
    public class DomainException : Exception
    {
        public string ErrorCode { get; set; }

        public DomainException()
        {

        }

        public DomainException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public DomainException(string errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
