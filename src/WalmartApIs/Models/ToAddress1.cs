using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// To Address - Customer's delivery address.
/// </summary>
public record ToAddress1
{
    /// <summary>
    /// ZIP or postal code of the customer's delivery address.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    /// <summary>
    /// Country code of the customer's delivery address (example, US).
    /// </summary>
    [JsonPropertyName("countryCode")]
    public required string CountryCode { get; init; }

    /// <summary>
    /// Street address lines for the customer's delivery address. Provide up to two lines.
    /// </summary>
    [JsonPropertyName("addressLines")]
    public required IReadOnlyList<string> AddressLines { get; init; }

    /// <summary>
    /// City of the customer's delivery address.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; init; }

    /// <summary>
    /// State or province of the customer's delivery address. Use the standard two-letter code where applicable.
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
