using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Package
{
    [JsonPropertyName("dimensions")]
    public required PackageDimensions Dimensions { get; init; }

    [JsonPropertyName("weight")]
    public required Weight Weight { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("insuredValue")]
    public Money? InsuredValue { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isHazmat")]
    public bool? IsHazmat { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerDeclaredValue")]
    public Money? SellerDeclaredValue { get; init; }

    /// <summary>
    /// Seller-supplied unique id for this package within the shipment.
    /// </summary>
    [JsonPropertyName("packageClientReferenceId")]
    public required string PackageClientReferenceId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("items")]
    public IReadOnlyList<Item3>? Items { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
