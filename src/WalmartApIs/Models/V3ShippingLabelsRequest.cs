using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record V3ShippingLabelsRequest
{
    /// <summary>
    /// The package type. For example, CUSTOM_PACKAGE', 'FEDEX_ENVELOPE', or 'FEDEX_PAK'.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global
    /// </para>
    /// </summary>
    [JsonPropertyName("packageType")]
    public required string PackageType { get; init; }

    /// <summary>
    /// Dimensions and weight of the package being shipped. Used together with packageType. For FEDEX_PAK or FEDEX_ENVELOPE, length/height/width are predetermined by the carrier and only weight is required. For CUSTOM_PACKAGE, all dimensions and weight are required.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("boxDimensions")]
    public required BoxDimensions3 BoxDimensions { get; init; }

    /// <summary>
    /// boxItems - this is a list of items that seller will be shipping in this package, all the items should be part of the purchaseOrder entered, lineId &amp; SKU are used to identify the exact item being shipped. Quantity tells us how many of that item we are shipping, it should be &lt;= the remaining unshipping quantity of the PO
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global
    /// </para>
    /// </summary>
    [JsonPropertyName("boxItems")]
    public required IReadOnlyList<BoxItem6> BoxItems { get; init; }

    /// <summary>
    /// Defines the origin address from which the order will be shipped. This represents the seller’s fulfillment center location.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fromAddress")]
    public FromAddress2? FromAddress { get; init; }

    /// <summary>
    /// Purchase Order Id.
    /// <para>
    /// &lt;b&gt;Applicable to SWW and WPS.&lt;/b&gt;
    /// </para>
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    public required string PurchaseOrderId { get; init; }

    /// <summary>
    /// The carrier name.
    /// <para>
    /// For US: This value maps to the 'shortName' parameter from a Supported carriers API response.
    /// </para>
    /// <para>
    /// Supported values for US: FedEx and USPS.
    /// </para>
    /// <para>
    /// Supported values for MX and CA: FedEx.
    /// </para>
    /// <para>
    /// Supported values for CA: MailAmericas.
    /// </para>
    /// <para>
    /// Supported values for CL: CBT sellers can use 'MailAmericas'. Domestic sellers can use 'Enviame'.
    /// </para>
    /// <para>
    /// &lt;b&gt;Applicable to SWW.&lt;/b&gt;
    /// </para>
    /// <para>
    ///
    /// </para>
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX | CL &lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("carrierName")]
    public required string CarrierName { get; init; }

    /// <summary>
    /// The carrier service type.
    /// <para>
    /// For US: This value maps to 'serviceTypes.name' parameter from Shipping Estimates API response
    /// </para>
    /// <para>
    /// Supported values for MX: 'FEDEX_INTERNATIONAL_PRIORITY' for fedExPak/fedExEnvelope package types, 'FEDEX_INTERNATIONAL_ECONOMY', and 'FEDEX_INTERNATIONAL_GROUND'
    /// </para>
    /// <para>
    /// Supported values for CA: 'FEDEX_INTERNATIONAL_PRIORITY' for single fedExPak/fedExEnvelope package types, 'FEDEX_INTERNATIONAL_ECONOMY', and 'FEDEX_INTERNATIONAL_GROUND'
    /// </para>
    /// <para>
    /// Supported values for CL: 'US_CL_MAIL_AMERICAS' and 'CN_CL_MAIL_AMERICAS'.
    /// </para>
    /// <para>
    /// &lt;b&gt;Applicable to SWW.&lt;/b&gt;
    /// </para>
    /// <para>
    ///
    /// </para>
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("carrierServiceType")]
    public required string CarrierServiceType { get; init; }

    /// <summary>
    /// AddOns Type. AddOns can be opted during label generation for a shipping. Supported values for AddOns are INSURANCE and SIGNATURE. We support standard SIGNATURE Type for now.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addOns")]
    public IReadOnlyList<AddOn7>? AddOns { get; init; }

    /// <summary>
    /// Return Address. This parameter is mandatory for orders using <c>Yanwen</c> for the carrier.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnAddress")]
    public ReturnAddress1? ReturnAddress { get; init; }

    /// <summary>
    /// The status for if the order contains a battery. This is mandatory for order using <c>Yanwen</c> as the carrier. Possible values, <c>true</c> or <c>false</c>.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hasBattery")]
    public bool? HasBattery { get; init; }

    /// <summary>
    /// The status for if the shipment contains hazardous material. Possible values, <c>true</c> or <c>false</c>.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hazmat")]
    public bool? Hazmat { get; init; }

    /// <summary>
    /// Account Type - BYOA (bring your own account), this is an US only initiative where sellers can bring their own FedEx accounts for creating labels instead of using the walmart ones.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("accountType")]
    public string? AccountType { get; init; }

    /// <summary>
    /// The size of the label. For example, A6,A8, LETTER_SIZE, or A4 for PDF response.
    /// <para>
    ///  Supported values for CL: 'LETTER_SIZE', 'A4', 'A6', 'A8' for MailAmericas
    /// </para>
    /// <para>
    ///  Supported values for CA: A6, LETTER_SIZE or A4 for PDF response
    /// </para>
    /// <para>
    ///
    /// </para>
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: CA | CL&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("labelSize")]
    public string? LabelSize { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
