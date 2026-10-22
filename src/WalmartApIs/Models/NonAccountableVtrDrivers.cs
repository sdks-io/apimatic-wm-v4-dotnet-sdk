using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Non Accountable drivers, which impacting the valid tracking rate
/// </summary>
public record NonAccountableVtrDrivers
{
    /// <summary>
    /// Rate of orders impacted due to miscellaneous reasons
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("miscellaneousRate")]
    public double? MiscellaneousRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
