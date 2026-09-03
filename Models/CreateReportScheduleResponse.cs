using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record CreateReportScheduleResponse
{
    [JsonPropertyName("reportScheduleId")]
    public required string ReportScheduleId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
