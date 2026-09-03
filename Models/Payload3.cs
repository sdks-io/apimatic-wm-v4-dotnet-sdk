using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Payload3
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rates")]
    public IReadOnlyList<Rate>? Rates { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ineligibleRates")]
    public IReadOnlyList<IneligibleRate>? IneligibleRates { get; init; }

    /// <summary>
    /// Opaque token to be passed back on subsequent purchaseShipment
    /// or getAdditionalInputs calls to identify this rate quote
    /// session.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("requestToken")]
    public string? RequestToken { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
