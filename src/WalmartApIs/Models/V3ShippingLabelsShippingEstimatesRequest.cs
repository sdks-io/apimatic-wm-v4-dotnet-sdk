using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3ShippingLabelsShippingEstimatesRequest
{
    /// <summary>
    /// Dimensions and weight of the package being shipped. For CUSTOM_PACKAGE, all dimensions and weight are required.
    /// </summary>
    [JsonPropertyName("boxDimensions")]
    public required BoxDimensions5 BoxDimensions { get; init; }

    /// <summary>
    /// Estimated delivery date.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deliverByDate")]
    public string? DeliverByDate { get; init; }

    /// <summary>
    /// ShipBy date.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipByDate")]
    public string? ShipByDate { get; init; }

    /// <summary>
    /// From address - Seller's fulfillment center address.
    /// </summary>
    [JsonPropertyName("fromAddress")]
    public required FromAddress4 FromAddress { get; init; }

    /// <summary>
    /// To Address - Customer's delivery address.
    /// </summary>
    [JsonPropertyName("toAddress")]
    public required ToAddress1 ToAddress { get; init; }

    /// <summary>
    /// Carriers List. This value maps to 'shortName' from All carriers API response.If not provided, it will fetch response for all service types.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carriers")]
    public IReadOnlyList<string>? Carriers { get; init; }

    /// <summary>
    /// Package Type. This value maps to 'packageTypeShortName' from All carrier package types API response.
    /// </summary>
    [JsonPropertyName("packageType")]
    public required string PackageType { get; init; }

    /// <summary>
    /// Delivery promise date flag. Pass 'false' if only services meeting promised delivery dates needs to be fetched, else 'true' to fetch all supported delivery dates
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("includeServicesNotMeetingDeliveryPromise")]
    public bool? IncludeServicesNotMeetingDeliveryPromise { get; init; }

    /// <summary>
    /// An unique identifier associated with the seller's purchase order.
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    public required string PurchaseOrderId { get; init; }

    /// <summary>
    /// boxItems - A list of items that the seller will be shipping in this package. Each item must correspond to a line item in the specified purchaseOrder. The lineId and SKU fields are used to uniquely identify the specific item being shipped.
    /// </summary>
    [JsonPropertyName("boxItems")]
    public required IReadOnlyList<BoxItem10> BoxItems { get; init; }

    /// <summary>
    /// addOns flag. Pass 'true' to fetch all addOns cost and we support two add ons type: SIGNATURE and INSURANCE. To get Insurance Estimate, please provide purchaseOrderId and boxItems details. By default, The value of addOns will be false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addOns")]
    public bool? AddOns { get; init; }

    /// <summary>
    /// hasBattery flag. Pass 'true' if the shipment consists of battery. This is a mandatory field for yanwen.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hasBattery")]
    public bool? HasBattery { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
