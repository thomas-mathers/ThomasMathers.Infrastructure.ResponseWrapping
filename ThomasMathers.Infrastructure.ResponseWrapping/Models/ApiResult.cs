namespace ThomasMathers.Infrastructure.ResponseWrapping.Models
{
    public record ApiResult
    {
        public string RequestId => Guid.NewGuid().ToString();
        public string? ErrorCode { get; init; }
        public string? ErrorMessage { get; init; }
        public object? Value { get; init; }

        public static ApiResult Failure(string errorCode, string? errorMessage = null, object? value = null)
        {
            return new ApiResult
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage,
                Value = value
            };
        }
    }
}
