using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Payload in the response for rejecting recommendations.
/// </summary>
public record Payload7
{
    /// <summary>
    /// Message confirming the rejection of the recommendations.
    ///  Message discription for US will be like 'The selected items will be removed shortly from the recommendations.' and for CA and MX : 'Recommendation Removed successfully. No of recommendation removed:5' &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
