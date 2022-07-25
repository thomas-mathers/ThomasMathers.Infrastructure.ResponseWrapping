namespace ThomasMathers.Infrastructure.ResponseWrapping.Models
{
    public record ApiValidationError
    {
        public string Property { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
