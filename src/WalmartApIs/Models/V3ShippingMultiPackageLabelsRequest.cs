using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3ShippingMultiPackageLabelsRequest
{
    /// <summary>
    /// Package Dimensions
    /// </summary>
    [JsonPropertyName("packageDimensions")]
    public required IReadOnlyList<PackageDimension> PackageDimensions { get; init; }

    /// <summary>
    /// Box Items, 1 total quantity supported for multiple packages
    /// </summary>
    [JsonPropertyName("boxItems")]
    public required IReadOnlyList<BoxItem8> BoxItems { get; init; }

    /// <summary>
    /// From address
    /// </summary>
    [JsonPropertyName("fromAddress")]
    public required FromAddress3 FromAddress { get; init; }

    /// <summary>
    /// Purchase order ID. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    public required string PurchaseOrderId { get; init; }

    /// <summary>
    /// Carrier name. The only supported carrier is 'FedEx'. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("carrierName")]
    public required string CarrierName { get; init; }

    /// <summary>
    /// Carrier service type. Supported values are - 'FEDEX_INTERNATIONAL_PRIORITY' for single fedExPak/fedExEnvelope package types, 'FEDEX_INTERNATIONAL_ECONOMY' and 'FEDEX_INTERNATIONAL_GROUND'. &lt;br/&gt;&lt;b&gt;Applicable to SWW only.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("carrierServiceType")]
    public required string CarrierServiceType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
