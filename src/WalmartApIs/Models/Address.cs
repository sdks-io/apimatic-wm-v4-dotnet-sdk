using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Address object representing a physical location (fulfillment center, return address, or delivery address).
/// </summary>
public record Address
{
    /// <summary>
    /// Name of the primary contact at the address location.
    /// </summary>
    [JsonPropertyName("contactName")]
    public required string ContactName { get; init; }

    /// <summary>
    /// Name of the company or organization at the address location.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("companyName")]
    public string? CompanyName { get; init; }

    /// <summary>
    /// Primary street address line.
    /// </summary>
    [JsonPropertyName("addressLine1")]
    public required string AddressLine1 { get; init; }

    /// <summary>
    /// Additional address details (example, suite or apartment number).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine2")]
    public string? AddressLine2 { get; init; }

    /// <summary>
    /// City of the address location.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; init; }

    /// <summary>
    /// State or province of the address. Use the standard two-letter code where applicable.
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; init; }

    /// <summary>
    /// ZIP or postal code of the address location.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    /// <summary>
    /// Country code of the address location (example, US, MX, CA).
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; init; }

    /// <summary>
    /// Phone number associated with the address location.
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; init; }

    /// <summary>
    /// Email address associated with the address location.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
