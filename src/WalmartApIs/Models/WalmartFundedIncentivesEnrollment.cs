using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
/// </summary>
public record WalmartFundedIncentivesEnrollment
{
    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmartFundedIncentivesEnrollment")]
    public string? WalmartFundedIncentivesEnrollmentValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
