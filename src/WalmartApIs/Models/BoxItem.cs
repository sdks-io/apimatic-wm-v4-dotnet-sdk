using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Box Items
/// </summary>
public record BoxItem
{
    /// <summary>
    /// sku of an item
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// Quantity of Item
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }

    /// <summary>
    /// PO Line Number
    /// </summary>
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    /// <summary>
    /// Name of the Product. This is a mandatory field if carrier is opted as 'Yanwen' and also for India(IN) to United States(US) shipping
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productName")]
    public string? ProductName { get; init; }

    /// <summary>
    /// Name of the Product in Mandarin. This is a mandatory field if carrier is opted as 'Yanwen'
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productNameInLocale")]
    public string? ProductNameInLocale { get; init; }

    /// <summary>
    /// HS Code. This is a mandatory field for India(IN) to United States(US) shipping
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hsCode")]
    public string? HsCode { get; init; }

    /// <summary>
    /// Origin State. This is a mandatory field for India(IN) to United States(US) shipping
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("originState")]
    public string? OriginState { get; init; }

    /// <summary>
    /// Origin City. This is a mandatory field for India(IN) to United States(US) shipping
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("originCity")]
    public string? OriginCity { get; init; }

    /// <summary>
    /// Country of Origin. This is a mandatory field for India(IN) to United States(US) shipping
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("countryOfOrigin")]
    public string? CountryOfOrigin { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
