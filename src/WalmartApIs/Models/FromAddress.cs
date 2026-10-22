using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// From address
/// </summary>
public record FromAddress
{
    /// <summary>
    /// Contact name
    /// </summary>
    [JsonPropertyName("contactName")]
    public required string ContactName { get; init; }

    /// <summary>
    /// Company name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("companyName")]
    public string? CompanyName { get; init; }

    /// <summary>
    /// Address Line 1
    /// </summary>
    [JsonPropertyName("addressLine1")]
    public required string AddressLine1 { get; init; }

    /// <summary>
    /// Address Line 2
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine2")]
    public string? AddressLine2 { get; init; }

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

    /// <summary>
    /// postal code
    /// </summary>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    /// <summary>
    /// country
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; init; }

    /// <summary>
    /// phone
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; init; }

    /// <summary>
    /// email
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
