using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Non Accountable drivers, which impacting the cancellations rate
/// </summary>
public record NonAccountableCancellationsDrivers
{
    /// <summary>
    /// Rate of orders cancelled due customer request
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerReqRate")]
    public double? CustomerReqRate { get; init; }

    /// <summary>
    /// Rate of orders cancelled due customer fraud
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerFraudRate")]
    public double? CustomerFraudRate { get; init; }

    /// <summary>
    /// Rate of orders cancelled due to miscellaneous reasons
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("miscellaneousRate")]
    public double? MiscellaneousRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
