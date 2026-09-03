using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The carrier for the inbound shipment.
/// </summary>
public record CommonCarrier
{
    /// <summary>
    /// The carrier code. For example, USPS or DHLEX.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("alphaCode")]
    [StringLength(1024, MinimumLength = 1)]
    public string? AlphaCode { get; init; }

    /// <summary>
    /// The name of the carrier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    [StringLength(1024, MinimumLength = 1)]
    public string? Name { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
