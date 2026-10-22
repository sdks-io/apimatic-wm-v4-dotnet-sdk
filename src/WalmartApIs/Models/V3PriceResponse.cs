using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3PriceResponse
{
    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("feedStatus")]
    public required string FeedStatus { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("feedSubmissionDate")]
    public required long FeedSubmissionDate { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("itemsReceived")]
    public required int ItemsReceived { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("itemsSucceeded")]
    public required int ItemsSucceeded { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("itemsFailed")]
    public required int ItemsFailed { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("itemsProcessing")]
    public required int ItemsProcessing { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("itemDetails")]
    public required ItemDetails6 ItemDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
