using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record PromotionInformation1
{
    /// <summary>
    /// | Market | Translation |
    /// | --- | ----------- |
    /// | US | ["Create", "Delete","Replace All"]|
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promotionSettingAction")]
    public PromotionSettingAction1? PromotionSettingAction { get; init; }

    /// <summary>
    /// Controls where discounted price is revealed to customers.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promotionPlacement")]
    public PromotionPlacement? PromotionPlacement { get; init; }

    /// <summary>
    /// | Market | Translation |
    /// | --- | ----------- |
    /// | US | ["Clearance", "Reduced"]|
    /// <para>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promotionType")]
    public PromotionType1? PromotionType { get; init; }

    /// <summary>
    /// Promotion price that you want to set for the SKU..&lt;br&gt; promotionPrice is required for Create.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promotionPrice")]
    public double? PromotionPrice { get; init; }

    /// <summary>
    /// The effective start date for a given promotion. Time should be specified in the UTC format.&lt;br&gt; promotionPriceStartDateTime is required for Create and Delete.  &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promotionPriceStartDateTime")]
    public DateTimeOffset? PromotionPriceStartDateTime { get; init; }

    /// <summary>
    /// The effective end date for a given promotion. Time should be specified in the UTC format.&lt;br&gt; promotionPriceEndDateTime is required for Create and Delete. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promotionPriceEndDateTime")]
    public DateTimeOffset? PromotionPriceEndDateTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
