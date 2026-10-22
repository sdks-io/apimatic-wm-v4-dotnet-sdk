using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Specifies the list of rewards.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
/// </summary>
public record Reward
{
    /// <summary>
    /// Specifies name of the eligible reward.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reward")]
    public string? RewardValue { get; init; }

    /// <summary>
    /// Indicates reward active status.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isRewardActive")]
    public bool? IsRewardActive { get; init; }

    /// <summary>
    /// Indicates if the reward has been overridden.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isRewardOverride")]
    public bool? IsRewardOverride { get; init; }

    /// <summary>
    /// Specifies the reward override action (approve or deny).&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rewardOverrideAction")]
    public string? RewardOverrideAction { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
