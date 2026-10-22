using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Non Accountable drivers, which impacting the refunds rate
/// </summary>
public record NonAccountableRefundsDrivers
{
    /// <summary>
    /// Refund rate of returns due to customer changed mind
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerChangedMindRate")]
    public double? CustomerChangedMindRate { get; init; }

    /// <summary>
    /// Refund rate of returns due to miscellaneous reasons
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("miscellaneousRate")]
    public double? MiscellaneousRate { get; init; }

    /// <summary>
    /// Refund rate of undelivered orders
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("undeliveredRate")]
    public double? UndeliveredRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
