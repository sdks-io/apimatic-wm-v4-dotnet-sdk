using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>cancelInboundPlan</c> response., The <c>generateDeliveryWindowOptions</c> response., The <c>confirmDeliveryWindowOptions</c> response., The <c>cancelSelfShipAppointment</c> response., The <c>generateSelfShipAppointmentSlots</c> response., The <c>setPackingInformation</c> response., The <c>generatePackingOptions</c> response., The <c>confirmPackingOption</c> response., The <c>generatePlacementOptions</c> response., The <c>confirmPlacementOption</c> response., The <c>generateTransportationOptions</c> response., The <c>confirmTransportationOptions</c> response., The <c>updateItemComplianceDetails</c> response., The <c>setPrepDetails</c> response., The <c>updateShipmentSourceAddress</c> response., The <c>updateShipmentTrackingDetails</c> response., The <c>generateShipmentContentUpdatePreviews</c> response., The <c>confirmShipmentContentUpdatePreview</c> response.
/// </summary>
public record CancelInboundPlanResponse
{
    /// <summary>
    /// UUID for the given operation.
    /// </summary>
    [JsonPropertyName("operationId")]
    [StringLength(38, MinimumLength = 36)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string OperationId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
