using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Reason the verification was rejected. Required when
/// <c>verificationStatus=REJECTED</c>; ignored otherwise. Mirrors
/// Amazon SP-API's enumerated rejection reasons.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RejectionReason>))]
public sealed record RejectionReason : StringEnum<RejectionReason>
{
    private RejectionReason(string value) : base(value)
    {
    }

    public static readonly RejectionReason BuyerCanceled = new("BUYER_CANCELED");

    public static readonly RejectionReason BuyerRejected = new("BUYER_REJECTED");

    public static readonly RejectionReason IdExpired = new("ID_EXPIRED");

    public static readonly RejectionReason IdInvalid = new("ID_INVALID");

    public static readonly RejectionReason IdUnderage = new("ID_UNDERAGE");

    public static readonly RejectionReason IdMismatch = new("ID_MISMATCH");

    public static readonly RejectionReason Other = new("OTHER");

    public static RejectionReason FromValue(string value) => FromValueCore(value);
}
