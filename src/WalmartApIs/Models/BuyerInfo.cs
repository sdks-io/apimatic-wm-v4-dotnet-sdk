using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Buyer contact projection. <c>buyerPhoneAnonymized</c> is masked to the
/// last 4 digits (e.g. <c><b>*-</b>*-0100</c>); the unmasked phone number is
/// never returned by the v4 API.
/// </summary>
public record BuyerInfo
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("buyerName")]
    public string? BuyerName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("buyerEmail")]
    [Format(FormatKind.Email)]
    public string? BuyerEmail { get; init; }

    /// <summary>
    /// Phone with everything but the last four digits masked.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("buyerPhoneAnonymized")]
    public string? BuyerPhoneAnonymized { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
