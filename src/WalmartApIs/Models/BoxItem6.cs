using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Box Items
/// </summary>
public record BoxItem6
{
    /// <summary>
    /// The item sku.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global
    /// </para>
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// Number of items.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global
    /// </para>
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }

    /// <summary>
    /// PO Line Number
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global
    /// </para>
    /// </summary>
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    /// <summary>
    /// The name of the product. This parameter is required if carrier is opted as 'Yanwen' and also for shipping from India(IN) to United-States(US).
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productName")]
    public string? ProductName { get; init; }

    /// <summary>
    /// The name of the product in Mandarin. This parameter is required if carrier is opted as 'Yanwen'.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productNameInLocale")]
    public string? ProductNameInLocale { get; init; }

    /// <summary>
    /// HS Code. This is a mandatory field for India (IN) to United States (US) shipping
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hsCode")]
    public string? HsCode { get; init; }

    /// <summary>
    /// Origin State. This is a mandatory field for India (IN) to United States (US) shipping
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("originState")]
    public string? OriginState { get; init; }

    /// <summary>
    /// Origin City. This is a mandatory field for India (IN) to United States (US) shipping
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("originCity")]
    public string? OriginCity { get; init; }

    /// <summary>
    /// Country of Origin. This is a mandatory field for India (IN) to United States (US) shipping
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("countryOfOrigin")]
    public string? CountryOfOrigin { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
