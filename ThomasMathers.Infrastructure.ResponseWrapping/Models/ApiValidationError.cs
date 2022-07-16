namespace ThomasMathers.Infrastructure.ResponseWrapping.Models
{
    public record ApiValidationError
    {
        public string Property { get; init; }
        public string Description { get; init; }
    }
}
