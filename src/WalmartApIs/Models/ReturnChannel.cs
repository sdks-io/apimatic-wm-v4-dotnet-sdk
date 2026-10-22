using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The channel via order return got initiated.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  US&lt;/b&gt;
/// </summary>
public record ReturnChannel
{
    /// <summary>
    /// Valid values are: ONLINE, IN_STORE, and CUSTOMER_CARE.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("channelName")]
    public string? ChannelName { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
