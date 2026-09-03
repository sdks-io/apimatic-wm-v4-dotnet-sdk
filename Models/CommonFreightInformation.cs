using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Freight information describes the SKUs that are in transit.
/// </summary>
public record CommonFreightInformation
{
    /// <summary>
    /// The type and amount of currency.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("declaredValue")]
    public CommonCurrency? DeclaredValue { get; init; }

    /// <summary>
    /// Freight class. Possible values: <c>NONE</c>, <c>FC_50</c>, <c>FC_55</c>, <c>FC_60</c>, <c>FC_65</c>, <c>FC_70</c>, <c>FC_77_5</c>, <c>FC_85</c>, <c>FC_92_5</c>, <c>FC_100</c>, <c>FC_110</c>, <c>FC_125</c>, <c>FC_150</c>, <c>FC_175</c>, <c>FC_200</c>, <c>FC_250</c>, <c>FC_300</c>, <c>FC_400</c>, <c>FC_500</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("freightClass")]
    [StringLength(1024, MinimumLength = 1)]
    public string? FreightClass { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
