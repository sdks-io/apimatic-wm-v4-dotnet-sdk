namespace WalmartApIs.Requests.ProductTypeDefinitions;

/// <summary>
/// The inputs of the SearchDefinitionsProductTypes operation.
/// </summary>
public sealed record SearchDefinitionsProductTypesRequest
{
    public string? Keywords { get; init; }

    public string? ItemName { get; init; }

    public string Locale { get; init; } = "en_US";
}
