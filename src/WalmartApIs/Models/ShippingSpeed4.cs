using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
/// </summary>
public record ShippingSpeed4
{
    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalIssue")]
    public int? TotalIssue { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingType")]
    public string? ShippingType { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("issueTitle")]
    public string? IssueTitle { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("issueDesc")]
    public string? IssueDesc { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("score")]
    public int? Score { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
