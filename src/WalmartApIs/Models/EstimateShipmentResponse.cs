using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// List of estimates
/// </summary>
public record EstimateShipmentResponse
{
    /// <summary>
    /// Service Type Group Name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("serviceTypeGroupName")]
    public string? ServiceTypeGroupName { get; init; }

    /// <summary>
    /// Service Type Group Display Name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("serviceTypeGroupDisplayName")]
    public string? ServiceTypeGroupDisplayName { get; init; }

    /// <summary>
    /// Carrier Service Type
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Carrier Service Type Display Name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; init; }

    /// <summary>
    /// Estimated Rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("estimatedRate")]
    public EstimatedRate? EstimatedRate { get; init; }

    /// <summary>
    /// Delivery Date
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deliveryDate")]
    public string? DeliveryDate { get; init; }

    /// <summary>
    /// Carrier Short Name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierName")]
    public string? CarrierName { get; init; }

    /// <summary>
    /// Carrier Display Name
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierDisplayName")]
    public string? CarrierDisplayName { get; init; }

    /// <summary>
    /// Delivery Promise Fulfilled
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isDeliveryPromiseFulfilled")]
    public bool? IsDeliveryPromiseFulfilled { get; init; }

    /// <summary>
    /// Add Ons Response
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addOns")]
    public IReadOnlyList<AddOnsResponse>? AddOns { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
