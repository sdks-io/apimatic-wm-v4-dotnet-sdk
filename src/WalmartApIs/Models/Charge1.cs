using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Charge1
{
    /// <summary>
    /// chargeType.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("chargeType")]
    public string? ChargeType { get; init; }

    /// <summary>
    /// chargeName.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("chargeName")]
    public string? ChargeName { get; init; }

    /// <summary>
    /// chargeAmount.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX | CA |CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("chargeAmount")]
    public Gmv? ChargeAmount { get; init; }

    /// <summary>
    /// tax.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tax")]
    public IReadOnlyList<Tax1>? Tax { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
