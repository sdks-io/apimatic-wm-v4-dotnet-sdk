using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Representation of a location used within the inbounding experience.
/// </summary>
public record CommonRegion
{
    /// <summary>
    /// ISO 3166 standard alpha-2 country code.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("countryCode")]
    [StringLength(1024, MinimumLength = 1)]
    public string? CountryCode { get; init; }

    /// <summary>
    /// State.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("state")]
    [StringLength(1024, MinimumLength = 1)]
    public string? State { get; init; }

    /// <summary>
    /// An identifier for a Ship Node.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("warehouseId")]
    [StringLength(1024, MinimumLength = 1)]
    public string? WarehouseId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
