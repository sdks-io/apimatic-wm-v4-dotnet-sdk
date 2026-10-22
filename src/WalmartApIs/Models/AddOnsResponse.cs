using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// List of add-ons returned for the estimate.
/// </summary>
public record AddOnsResponse
{
    /// <summary>
    /// Name of the AddOn type.
    /// </summary>
    [JsonPropertyName("name")]
    public required Name Name { get; init; }

    /// <summary>
    /// Charge of add-on type.
    /// </summary>
    [JsonPropertyName("charge")]
    public required ComparisonPrice Charge { get; init; }

    /// <summary>
    /// Declared value of shipment. This value is applicable in case of INSURANCE add-on type only.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("declaredValue")]
    public ComparisonPrice? DeclaredValue { get; init; }

    /// <summary>
    /// Reference link for the add-on type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refLink")]
    public string? RefLink { get; init; }

    /// <summary>
    /// Status of the add-on type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
