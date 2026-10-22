using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// From address - Seller's fulfilment center address.
/// </summary>
public record ShipmentLocation
{
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    [JsonPropertyName("countryCode")]
    public required string CountryCode { get; init; }

    /// <summary>
    /// addressLines
    /// </summary>
    [JsonPropertyName("addressLines")]
    public required IReadOnlyList<string> AddressLines { get; init; }

    /// <summary>
    /// city
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; init; }

    /// <summary>
    /// state
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
