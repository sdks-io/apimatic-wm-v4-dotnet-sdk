using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Charge
{
    /// <summary>
    /// The category type. (e.g., 'PRODUCT' or 'FEE').&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("chargeCategory")]
    public string? ChargeCategory { get; init; }

    /// <summary>
    /// The category type. (e.g., 'PRODUCT' or 'FEE').&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX | CA | CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("chargeType")]
    public string? ChargeType { get; init; }

    /// <summary>
    /// If chargeType is PRODUCT, chargeName is Item Price. If chargeType is SHIPPING, chargeName is Shipping.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("chargeName")]
    public string? ChargeName { get; init; }

    /// <summary>
    /// Price of One unit of item, in this order line.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("chargePerUnit")]
    public ChargePerUnit? ChargePerUnit { get; init; }

    /// <summary>
    /// Is this charge a discount, which then needs to be subtracted from the refund.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isDiscount")]
    public bool? IsDiscount { get; init; }

    /// <summary>
    /// Should this charge be included in the refund computation.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isBillable")]
    public bool? IsBillable { get; init; }

    /// <summary>
    /// Taxes for each charge.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tax")]
    public IReadOnlyList<Tax>? Tax { get; init; }

    /// <summary>
    /// Used only for 1P.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("references")]
    public IReadOnlyList<VariantInfo>? References { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
