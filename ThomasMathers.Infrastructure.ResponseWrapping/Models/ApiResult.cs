namespace ThomasMathers.Infrastructure.ResponseWrapping.Models
{
    public record ApiResult
    {
        public string RequestId => Guid.NewGuid().ToString();
        public string? ErrorCode { get; init; }
        public string? ErrorMessage { get; init; }
        public object? Error { get; init; }
        public object? Value { get; init; }
    }
}
