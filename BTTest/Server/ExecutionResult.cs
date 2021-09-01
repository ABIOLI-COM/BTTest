using System;

namespace BTTest.Server
{
    public record ExecutionResult<T>
    {
        public T Result { get; init; }
        public string ErrorMessage { get; init; }

        private ExecutionResult(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
        }

        public bool IsError() => !string.IsNullOrEmpty(ErrorMessage);
        public bool IsResult() => !IsError();

        public static ExecutionResult<T> BuildPositive(T result) => new(result, string.Empty);

        public static ExecutionResult<T> BuildNegative(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ApplicationException("Fatal error: no error message");
            }

            return new(default, errorMessage);
        }
    }
}
