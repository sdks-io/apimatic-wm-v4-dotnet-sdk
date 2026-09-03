using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Verification requirements for an order containing regulated
/// items. Mirrors Amazon SP-API Orders v0 <c>RegulatedInformation</c>
/// plus a <c>regulatedCategory</c> discriminator so a caller can short-
/// circuit when the order is not regulated at all.
/// </summary>
public record RegulatedInfo
{
    /// <summary>
    /// Top-level category of regulation that applies. NOT_REGULATED
    /// means no verification is required and the rest of the fields
    /// are informational only.
    /// </summary>
    [JsonPropertyName("regulatedCategory")]
    public required RegulatedCategory RegulatedCategory { get; init; }

    /// <summary>
    /// How the buyer must prove identity at delivery. NONE means no
    /// verification is required (NOT_REGULATED orders always return
    /// NONE).
    /// </summary>
    [JsonPropertyName("requiredVerificationMethod")]
    public required RequiredVerificationMethod RequiredVerificationMethod { get; init; }

    /// <summary>
    /// Minimum buyer age in years (e.g. 21 for alcohol in the US).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("requiredAgeMinimum")]
    [Minimum(0)]
    [Maximum(120)]
    public int? RequiredAgeMinimum { get; init; }

    /// <summary>
    /// True when the carrier must capture a signature on delivery.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("signatureRequired")]
    public bool? SignatureRequired { get; init; }

    /// <summary>
    /// True when the buyer's date of birth must be captured / cross-checked.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("buyerDateOfBirthRequired")]
    public bool? BuyerDateOfBirthRequired { get; init; }

    /// <summary>
    /// Any value-added services attached to the order that are
    /// relevant to the regulated workflow (e.g. signed-delivery,
    /// adult-signature). Empty when none apply.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("valueAddedServices")]
    public IReadOnlyList<ValueAddedService>? ValueAddedServices { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
