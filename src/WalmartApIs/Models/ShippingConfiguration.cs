using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ShippingConfiguration
{
    /// <summary>
    /// Type of shipping configuration to where current SKU should be migrated to. Eligible values for the field are: Simplified Shipping Settings &amp; Manual Template
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemShippingConfiguration")]
    public string? ItemShippingConfiguration { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
