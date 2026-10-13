using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Error object containing information about what went wrong.
/// </summary>
public record CommonError
{
    /// <summary>
    /// An error code that identifies the type of error that occurred.
    /// </summary>
    [JsonPropertyName("code")]
    [StringLength(256, MinimumLength = 1)]
    public required string Code { get; init; }

    /// <summary>
    /// A message that describes the error condition.
    /// </summary>
    [JsonPropertyName("message")]
    [StringLength(2048, MinimumLength = 1)]
    public required string Message { get; init; }

    /// <summary>
    /// Additional details that can help the caller understand or fix the issue.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("details")]
    [StringLength(8192, MinimumLength = 0)]
    public string? Details { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
