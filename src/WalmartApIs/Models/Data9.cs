using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Response payload for the operation.
/// </summary>
public record Data9
{
    /// <summary>
    /// Manifest ID returned by the create scan form API. Use this value to download the scan form or for future reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("manifestId")]
    public string? ManifestId { get; init; }

    /// <summary>
    /// Status of the scan form request. Example: SUCCESS.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
