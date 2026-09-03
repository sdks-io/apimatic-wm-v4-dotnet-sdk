using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>updateShipmentSourceAddress</c> request.
/// </summary>
public record UpdateShipmentSourceAddressRequest
{
    /// <summary>
    /// Specific details to identify a place (input variant — phone required).
    /// </summary>
    [JsonPropertyName("address")]
    public required CommonAddressInput Address { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
