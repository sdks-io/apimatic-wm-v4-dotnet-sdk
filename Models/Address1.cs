using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Address1
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("addressLine1")]
    public required string AddressLine1 { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine2")]
    public string? AddressLine2 { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressLine3")]
    public string? AddressLine3 { get; init; }

    [JsonPropertyName("city")]
    public required string City { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("county")]
    public string? County { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("district")]
    public string? District { get; init; }

    [JsonPropertyName("stateOrRegion")]
    public required string StateOrRegion { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("municipality")]
    public string? Municipality { get; init; }

    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    [JsonPropertyName("countryCode")]
    public string CountryCode { get; init; } = "US";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isCommercialAddress")]
    public bool? IsCommercialAddress { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
