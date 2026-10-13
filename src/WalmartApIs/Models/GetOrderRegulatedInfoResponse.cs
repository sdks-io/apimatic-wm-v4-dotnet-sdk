using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record GetOrderRegulatedInfoResponse
{
    /// <summary>
    /// Verification requirements for an order containing regulated
    /// items. Mirrors Amazon SP-API Orders v0 <c>RegulatedInformation</c>
    /// plus a <c>regulatedCategory</c> discriminator so a caller can short-
    /// circuit when the order is not regulated at all.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payload")]
    public RegulatedInfo? Payload { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
