using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// From address - Seller's fulfillment center address.
/// </summary>
public record FromAddress4
{
    /// <summary>
    /// ZIP or postal code of the seller's fulfillment center.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    /// <summary>
    /// Country code of the seller's fulfillment center (example, US, CN, IN).
    /// </summary>
    [JsonPropertyName("countryCode")]
    public required string CountryCode { get; init; }

    /// <summary>
    /// Street address lines for the seller's fulfillment center. Provide up to two lines. Provide up to two lines.
    /// </summary>
    [JsonPropertyName("addressLines")]
    public required IReadOnlyList<string> AddressLines { get; init; }

    /// <summary>
    /// City of the seller's fulfillment center.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; init; }

    /// <summary>
    /// State or province of the seller's fulfillment center. Use the standard two-letter code where applicable.
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
