using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record GetOrderBuyerInfoResponse
{
    /// <summary>
    /// Buyer contact projection. <c>buyerPhoneAnonymized</c> is masked to the
    /// last 4 digits (e.g. <c><b>*-</b>*-0100</c>); the unmasked phone number is
    /// never returned by the v4 API.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payload")]
    public BuyerInfo? Payload { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
