using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record PromotionInformation
{
    /// <summary>
    /// | Market | Translation |
    /// | --- | ----------- |
    /// | CA  | ["Create", "Delete","Replace All"]|
    /// | MX &amp; CL | ["Crear", "Eliminar","Reemplazar todo"]|
    /// <para>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL
    /// </para>
    /// </summary>
    [JsonPropertyName("promotionSettingAction")]
    public required PromotionSettingAction PromotionSettingAction { get; init; }

    /// <summary>
    /// | Market | Translation |
    /// | --- | ----------- |
    /// | CA  | ["Clearance", "Reduced"]|
    /// | MX | ["Rebaja", "Liquidación"]|
    /// <para>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX &lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("promotionType")]
    public required PromotionType PromotionType { get; init; }

    /// <summary>
    /// Promotion price that you want to set for the SKU.&lt;br&gt; promotionPrice is required for Create.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promotionPrice")]
    public double? PromotionPrice { get; init; }

    /// <summary>
    /// The effective start date for a given promotion. Time should be specified in the UTC format.&lt;br&gt; promotionPriceStartDateTime is required for Create and Delete. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promotionPriceStartDateTime")]
    public DateTimeOffset? PromotionPriceStartDateTime { get; init; }

    /// <summary>
    /// The effective end date for a given promotion. Time should be specified in the UTC format.&lt;br&gt; promotionPriceEndDateTime is required for Create and Delete. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promotionPriceEndDateTime")]
    public DateTimeOffset? PromotionPriceEndDateTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
