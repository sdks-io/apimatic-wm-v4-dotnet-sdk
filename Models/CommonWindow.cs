using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains a start and end DateTime representing a time range.
/// </summary>
public record CommonWindow
{
    /// <summary>
    /// The timestamp at which this window can no longer be edited.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("editableUntil")]
    public DateTimeOffset? EditableUntil { get; init; }

    /// <summary>
    /// The end timestamp of the window.
    /// </summary>
    [JsonPropertyName("end")]
    public required DateTimeOffset End { get; init; }

    /// <summary>
    /// The start timestamp of the window.
    /// </summary>
    [JsonPropertyName("start")]
    public required DateTimeOffset Start { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
