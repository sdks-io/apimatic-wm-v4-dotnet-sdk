using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Tracking information input for LTL and SPD shipments.
/// </summary>
public record CommonTrackingDetailsInput
{
    /// <summary>
    /// Contains input information to update LTL tracking information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ltlTrackingDetail")]
    public CommonLtlTrackingDetailInput? LtlTrackingDetail { get; init; }

    /// <summary>
    /// Contains input information to update SPD tracking information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("spdTrackingDetail")]
    public CommonSpdTrackingDetailInput? SpdTrackingDetail { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
