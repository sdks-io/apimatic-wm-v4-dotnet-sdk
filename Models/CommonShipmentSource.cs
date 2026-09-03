using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Specifies the 'ship from' address for the shipment.
/// </summary>
public record CommonShipmentSource
{
    /// <summary>
    /// Specific details to identify a place.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("address")]
    public CommonAddress? Address { get; init; }

    /// <summary>
    /// The type of source for this shipment. Possible values: <c>SELLER_FACILITY</c>.
    /// </summary>
    [JsonPropertyName("sourceType")]
    [StringLength(1024, MinimumLength = 1)]
    public required string SourceType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
