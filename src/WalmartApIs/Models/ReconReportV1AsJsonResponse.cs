using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ReconReportV1AsJsonResponse
{
    /// <summary>
    /// content of the CSV file in the list format, each element in the list represents the row in CSV file.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reportData")]
    public IReadOnlyList<JsonObject>? ReportData { get; init; }

    /// <summary>
    /// this field will be used in subsequent calls to fetch next set of records.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nextOffset")]
    public long? NextOffset { get; init; }

    /// <summary>
    /// records returned in the current response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalRecords")]
    public int? TotalRecords { get; init; }

    /// <summary>
    /// total number of lines in the the file.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
