using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Return Address. This parameter is mandatory for orders using <c>Yanwen</c> for the carrier.
/// <para>
/// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
/// </para>
/// </summary>
public record ReturnAddress1
{
    /// <summary>
    /// The name of the primary contact at the return address location.
    /// </summary>
    [JsonPropertyName("contactName")]
    public required string ContactName { get; init; }

    /// <summary>
    /// Primary street address of the return location.
    /// </summary>
    [JsonPropertyName("addressLine1")]
    public required string AddressLine1 { get; init; }

    /// <summary>
    /// The additional address details for the return location (example, suite or apartment number).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine2")]
    public string? AddressLine2 { get; init; }

    /// <summary>
    /// City of the return address location.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; init; }

    /// <summary>
    /// State or province of the return address. Use the standard two-letter code where applicable.
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    /// <summary>
    /// ZIP or postal code of the return address location.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    /// <summary>
    /// Country code of the return address location (example, US, CN).
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; init; }

    /// <summary>
    /// Phone number associated with the return address location.
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; init; }

    /// <summary>
    /// Email address associated with the return address location.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// Seller's ship node identifier associated with the return location.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNode")]
    public string? ShipNode { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
