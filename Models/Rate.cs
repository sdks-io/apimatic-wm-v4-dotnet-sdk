using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Rate
{
    [JsonPropertyName("rateId")]
    public required string RateId { get; init; }

    [JsonPropertyName("carrier")]
    public required Carrier Carrier { get; init; }

    [JsonPropertyName("service")]
    public required Service Service { get; init; }

    [JsonPropertyName("totalCharge")]
    public required Money TotalCharge { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("billedWeight")]
    public Weight? BilledWeight { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expirationTime")]
    public DateTimeOffset? ExpirationTime { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promise")]
    public Promise? Promise { get; init; }

    /// <summary>
    /// List of label/document formats supported by this rate.
    /// Each entry shape matches industry-standard
    /// SupportedDocumentSpecification; tier-1 fidelity is
    /// sufficient for v4 — see TODO at top of file.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("supportedDocumentSpecifications")]
    public IReadOnlyList<object>? SupportedDocumentSpecifications { get; init; }

    /// <summary>
    /// Value-added services available for purchase at this rate
    /// (signature, COD, dangerous goods, etc). Compressed shape;
    /// full fidelity tracked in a follow-up PR.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("availableValueAddedServices")]
    public IReadOnlyList<object>? AvailableValueAddedServices { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
