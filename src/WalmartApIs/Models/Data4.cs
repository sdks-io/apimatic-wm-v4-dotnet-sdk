using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Response payload containing the generated label tracking details and, when requested, the label file.
/// </summary>
public record Data4
{
    /// <summary>
    /// The purchase order ID.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; init; }

    /// <summary>
    /// Tracking Number
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trackingNo")]
    public string? TrackingNo { get; init; }

    /// <summary>
    /// Box Items
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxItems")]
    public IReadOnlyList<BoxItem7>? BoxItems { get; init; }

    /// <summary>
    /// Carrier short name.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierName")]
    public string? CarrierName { get; init; }

    /// <summary>
    /// Carrier full name.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global  &lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierFullName")]
    public string? CarrierFullName { get; init; }

    /// <summary>
    /// Carrier service type.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierServiceType")]
    public string? CarrierServiceType { get; init; }

    /// <summary>
    /// Tracking URL.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trackingUrl")]
    public string? TrackingUrl { get; init; }

    /// <summary>
    /// Add-on response items.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addOns")]
    public IReadOnlyList<AddOn8>? AddOns { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
