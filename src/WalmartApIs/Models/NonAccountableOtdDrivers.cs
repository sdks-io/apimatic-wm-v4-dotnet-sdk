using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Non Accountable drivers, which impacting the on time delivery rate
/// </summary>
public record NonAccountableOtdDrivers
{
    /// <summary>
    /// Rate of orders impacted due to carrier delays
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierDelaysRate")]
    public double? CarrierDelaysRate { get; init; }

    /// <summary>
    /// Rate of orders impacted due to carrier exceptions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierExceptionRate")]
    public double? CarrierExceptionRate { get; init; }

    /// <summary>
    /// Rate of orders impacted due to miscellaneous reasons
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("miscellaneousRate")]
    public double? MiscellaneousRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
