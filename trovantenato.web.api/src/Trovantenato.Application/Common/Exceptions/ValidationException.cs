using FluentValidation.Results;

namespace Trovantenato.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
        : base("Ocorreram uma ou mais falhas na validação.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
        public ValidationException(string field, string message)
        {
            string[] listMessage = new string[1] { message };

            Errors = new Dictionary<string, string[]>()
        {
            { field, listMessage}
        };
        }
        public ValidationException(string name, object key, string message)
        {
            string msg = $"{key} - {message}";
            string[] listMessage = new string[1] { msg };

            Errors = new Dictionary<string, string[]>()
        {
            { name, listMessage}
        };
        }


        public IDictionary<string, string[]> Errors { get; }
    }
}
