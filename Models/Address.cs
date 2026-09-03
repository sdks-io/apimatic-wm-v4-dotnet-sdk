using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Address
{
    [JsonPropertyName("name")]
    [MaxLength(50)]
    public required string Name { get; init; }

    [JsonPropertyName("addressLine1")]
    [MaxLength(60)]
    public required string AddressLine1 { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine2")]
    [MaxLength(60)]
    public string? AddressLine2 { get; init; }

    [JsonPropertyName("city")]
    [MaxLength(50)]
    public required string City { get; init; }

    [JsonPropertyName("stateOrRegion")]
    [MaxLength(50)]
    public required string StateOrRegion { get; init; }

    [JsonPropertyName("postalCode")]
    [MaxLength(20)]
    public required string PostalCode { get; init; }

    [JsonPropertyName("countryCode")]
    [MaxLength(2)]
    public string CountryCode { get; init; } = "US";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("phone")]
    [MaxLength(20)]
    public string? Phone { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
