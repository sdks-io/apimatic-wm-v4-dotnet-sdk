using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Items status included in the response list.
/// </summary>
public record Issues1
{
    /// <summary>
    /// The unique Product ID assigned to the item.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: US only</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productId")]
    public string? ProductId { get; init; }

    /// <summary>
    /// The Product ID type of the item.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: US only</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productIdType")]
    public string? ProductIdType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
