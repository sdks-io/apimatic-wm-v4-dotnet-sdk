using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Records the seller's verification decision for a regulated
/// order. REJECTED requires a <c>rejectionReason</c>; APPROVED leaves
/// <c>rejectionReason</c> unset.
/// </summary>
public record UpdateVerificationStatusRequest
{
    /// <summary>
    /// Outcome of the doorstep / pickup identity verification.
    /// </summary>
    [JsonPropertyName("verificationStatus")]
    public required VerificationStatus VerificationStatus { get; init; }

    /// <summary>
    /// Reason the verification was rejected. Required when
    /// <c>verificationStatus=REJECTED</c>; ignored otherwise. Mirrors
    /// Amazon SP-API's enumerated rejection reasons.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rejectionReason")]
    public RejectionReason? RejectionReason { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
