using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record FeedProcessingSummary
{
    /// <summary>
    /// Total number of records in the submitted feed
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalRecordCount")]
    public int? TotalRecordCount { get; init; }

    /// <summary>
    /// Number of records processed so far
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("processedRecordCount")]
    public int? ProcessedRecordCount { get; init; }

    /// <summary>
    /// Number of records processed successfully
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("successCount")]
    public int? SuccessCount { get; init; }

    /// <summary>
    /// Number of records that failed processing
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errorCount")]
    public int? ErrorCount { get; init; }

    /// <summary>
    /// Number of records processed with warnings
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("warningCount")]
    public int? WarningCount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
