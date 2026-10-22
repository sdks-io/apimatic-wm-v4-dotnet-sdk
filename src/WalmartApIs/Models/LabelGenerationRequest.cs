using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record LabelGenerationRequest
{
    /// <summary>
    /// Package Type. This value maps to 'packageTypeShortName' from Supported carrier package types API response.
    /// </summary>
    [JsonPropertyName("packageType")]
    public required string PackageType { get; init; }

    /// <summary>
    /// Box dimensions and weight for the shipping package.
    /// </summary>
    [JsonPropertyName("boxDimensions")]
    public required BoxDimensions1 BoxDimensions { get; init; }

    /// <summary>
    /// Box Items
    /// </summary>
    [JsonPropertyName("boxItems")]
    public required IReadOnlyList<BoxItem> BoxItems { get; init; }

    /// <summary>
    /// From address
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fromAddress")]
    public FromAddress? FromAddress { get; init; }

    /// <summary>
    /// Purchase order ID
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    public required string PurchaseOrderId { get; init; }

    /// <summary>
    /// Carrier name. This value maps to 'shortName' from Supported carriers API response. Currently FedEx and USPS are supported carriers.
    /// </summary>
    [JsonPropertyName("carrierName")]
    public required string CarrierName { get; init; }

    /// <summary>
    /// Carrier service type. This value maps to 'serviceTypes.name' from Shipping Estimates API response
    /// </summary>
    [JsonPropertyName("carrierServiceType")]
    public required string CarrierServiceType { get; init; }

    /// <summary>
    /// Add-ons type. Add-ons can be opted during label generation for a shipping. Supported values for add-ons are INSURANCE and SIGNATURE. We support standard SIGNATURE Type for now.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addOns")]
    public IReadOnlyList<AddOn>? AddOns { get; init; }

    /// <summary>
    /// Return Address. This is only mandatory field for yanwen
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnAddress")]
    public ReturnAddress? ReturnAddress { get; init; }

    /// <summary>
    /// hasBattery flag. Pass 'true' if the shipment consists of battery. This is a mandatory field for yanwen.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hasBattery")]
    public bool? HasBattery { get; init; }

    /// <summary>
    /// hazmat flag. Pass 'true' if the shipment consists of hazardous material.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hazmat")]
    public bool? Hazmat { get; init; }

    /// <summary>
    /// Account Type. This is a mandatory field in case of BYOA
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("accountType")]
    public string? AccountType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
