using Inventory.Domain.Common.Interfaces;
namespace Inventory.Domain.Common
{
    public class Result<T> : IResult<T>
    {
        public List<string> Messages { get; set; } = new List<string>();

        public bool Succeeded { get; set; }

        public T Data { get; set; }

        public Exception Exception { get; set; }

        public int Code { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                Succeeded = true,
                Data = data
            };
        }

        public static Result<T> Success(T data, string message)
        {
            return new Result<T>
            {
                Succeeded = true,
                Messages = new List<string> { message },
                Data = data
            };
        }

        public static Result<T> Failure(string message)
        {
            return new Result<T>
            {
                Succeeded = false,
                Messages = new List<string> { message }
            };
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }

        public static Task<Result<T>> FailureAsync(string message)
        {
            return Task.FromResult(Failure(message));
        }
    }
}
