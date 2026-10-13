using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Specific details to identify a place (input variant — phone required).
/// </summary>
public record CommonAddressInput
{
    /// <summary>
    /// Street address information.
    /// </summary>
    [JsonPropertyName("addressLine1")]
    [StringLength(180, MinimumLength = 1)]
    public required string AddressLine1 { get; init; }

    /// <summary>
    /// Additional street address information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine2")]
    [StringLength(60, MinimumLength = 1)]
    public string? AddressLine2 { get; init; }

    /// <summary>
    /// The city.
    /// </summary>
    [JsonPropertyName("city")]
    [StringLength(30, MinimumLength = 1)]
    public required string City { get; init; }

    /// <summary>
    /// The name of the business.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("companyName")]
    [StringLength(50, MinimumLength = 1)]
    public string? CompanyName { get; init; }

    /// <summary>
    /// The country code in two-character ISO 3166-1 alpha-2 format.
    /// </summary>
    [JsonPropertyName("countryCode")]
    [StringLength(2, MinimumLength = 2)]
    [RegularExpression("^[A-Z]{2}$")]
    public required string CountryCode { get; init; }

    /// <summary>
    /// The district or county.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("districtOrCounty")]
    [StringLength(50, MinimumLength = 1)]
    public string? DistrictOrCounty { get; init; }

    /// <summary>
    /// The email address.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("email")]
    [StringLength(1024, MinimumLength = 1)]
    public string? Email { get; init; }

    /// <summary>
    /// The name of the individual who is the primary contact.
    /// </summary>
    [JsonPropertyName("name")]
    [StringLength(50, MinimumLength = 1)]
    public required string Name { get; init; }

    /// <summary>
    /// The phone number.
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    [StringLength(20, MinimumLength = 1)]
    public required string PhoneNumber { get; init; }

    /// <summary>
    /// The postal code.
    /// </summary>
    [JsonPropertyName("postalCode")]
    [StringLength(32, MinimumLength = 1)]
    public required string PostalCode { get; init; }

    /// <summary>
    /// The state or province code.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stateOrProvinceCode")]
    [StringLength(64, MinimumLength = 1)]
    public string? StateOrProvinceCode { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
