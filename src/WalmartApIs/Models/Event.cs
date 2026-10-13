using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Event
{
    /// <summary>
    /// Carrier-normalized event code (e.g. PICKED_UP, OUT_FOR_DELIVERY, DELIVERED, EXCEPTION).
    /// </summary>
    [JsonPropertyName("eventCode")]
    public required string EventCode { get; init; }

    [JsonPropertyName("eventTime")]
    public required DateTimeOffset EventTime { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("location")]
    public Location? Location { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
