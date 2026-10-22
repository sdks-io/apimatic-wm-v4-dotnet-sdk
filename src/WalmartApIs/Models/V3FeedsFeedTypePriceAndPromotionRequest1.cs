using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.AnyOf;

namespace WalmartApIs.Models;

public record V3FeedsFeedTypePriceAndPromotionRequest1
{
    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("MPItemFeedHeader")]
    public MpItemFeedHeader? MpItemFeedHeader { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("MPItem")]
    public MpItem111? MpItem { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
