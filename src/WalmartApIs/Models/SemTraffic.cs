using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Performance data of the campaign
/// </summary>
public record SemTraffic
{
    /// <summary>
    /// The number of times the advertisement was displayed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("impressions")]
    public int? Impressions { get; init; }

    /// <summary>
    /// The number of times the advertisement was clicked.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("clicks")]
    public int? Clicks { get; init; }

    /// <summary>
    /// Click-Through Rate (CTR), calculated as clicks divided by impressions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ctr")]
    public double? Ctr { get; init; }

    /// <summary>
    /// Total amount spent on ads.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("adspend")]
    public double? Adspend { get; init; }

    /// <summary>
    /// Cost Per Click (CPC), calculated as ad spend divided by clicks.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cpc")]
    public double? Cpc { get; init; }

    /// <summary>
    /// Gross Merchandise Value (GMV), representing total sales generated.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gmv")]
    public double? Gmv { get; init; }

    /// <summary>
    /// Return on Ad Spend (ROAS), calculated as GMV divided by ad spend.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("roas")]
    public double? Roas { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
