namespace ThomasMathers.Common.ResponseWrapping.Models
{
    public record ApiValidationError
    {
        public string Property { get; init; }
        public string Description { get; init; }
    }
}
