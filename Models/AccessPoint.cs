using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record AccessPoint
{
    [JsonPropertyName("accessPointId")]
    public required string AccessPointId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public Type11? Type { get; init; }

    [JsonPropertyName("address")]
    public required Address1 Address { get; init; }

    /// <summary>
    /// Per-day operating hours. Compressed shape; full
    /// DayOfWeekTimeMap fidelity tracked in a follow-up PR.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("operatingHours")]
    public object? OperatingHours { get; init; }

    /// <summary>
    /// IANA timezone name (e.g. America/Los_Angeles).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
