using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record PurchaseShipmentRequest
{
    /// <summary>
    /// requestToken returned by the prior getRates response.
    /// </summary>
    [JsonPropertyName("requestToken")]
    public required string RequestToken { get; init; }

    /// <summary>
    /// The chosen rateId from the getRates response.
    /// </summary>
    [JsonPropertyName("rateId")]
    public required string RateId { get; init; }

    [JsonPropertyName("requestedDocumentSpecification")]
    public required RequestedDocumentSpecification RequestedDocumentSpecification { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("requestedValueAddedServices")]
    public IReadOnlyList<RequestedValueAddedService>? RequestedValueAddedServices { get; init; }

    /// <summary>
    /// Carrier/service-specific inputs validated against the schema
    /// returned by getAdditionalInputs.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("additionalInputs")]
    public object? AdditionalInputs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
