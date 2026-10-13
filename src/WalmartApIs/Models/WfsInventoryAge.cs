using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Units grouped by storage duration. Used for long-term storage fee assessment.
/// 7 buckets: days365Plus, days365To450, and days450Plus reflect the upstream
/// split-aged-buckets feature — days365Plus is the pre-split total.
/// </summary>
public record WfsInventoryAge
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("days0To90")]
    [Minimum(0)]
    public int? Days0To90 { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("days91To180")]
    [Minimum(0)]
    public int? Days91To180 { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("days181To270")]
    [Minimum(0)]
    public int? Days181To270 { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("days271To365")]
    [Minimum(0)]
    public int? Days271To365 { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("days365Plus")]
    [Minimum(0)]
    public int? Days365Plus { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("days365To450")]
    [Minimum(0)]
    public int? Days365To450 { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("days450Plus")]
    [Minimum(0)]
    public int? Days450Plus { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
