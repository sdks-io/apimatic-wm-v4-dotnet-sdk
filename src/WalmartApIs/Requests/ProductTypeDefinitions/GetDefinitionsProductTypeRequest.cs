namespace WalmartApIs.Requests.ProductTypeDefinitions;

/// <summary>
/// The inputs of the GetDefinitionsProductType operation.
/// </summary>
public sealed record GetDefinitionsProductTypeRequest
{
    public required string ProductType { get; init; }

    public string? SellerId { get; init; }

    public string Locale { get; init; } = "en_US";
}
