using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Reason the verification was rejected. Required when
/// <c>verificationStatus=REJECTED</c>; ignored otherwise. Mirrors
/// Amazon SP-API's enumerated rejection reasons.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RejectionReason>))]
public sealed record RejectionReason : OpenStringEnum<RejectionReason>
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

    public TResult Match<TResult>(Func<TResult> onBuyerCanceled,
        Func<TResult> onBuyerRejected,
        Func<TResult> onIdExpired,
        Func<TResult> onIdInvalid,
        Func<TResult> onIdUnderage,
        Func<TResult> onIdMismatch,
        Func<TResult> onOther,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == BuyerCanceled => onBuyerCanceled(),
            _ when this == BuyerRejected => onBuyerRejected(),
            _ when this == IdExpired => onIdExpired(),
            _ when this == IdInvalid => onIdInvalid(),
            _ when this == IdUnderage => onIdUnderage(),
            _ when this == IdMismatch => onIdMismatch(),
            _ when this == Other => onOther(),
            _ => otherwise(Value)
        };

    public void Match(Action onBuyerCanceled,
        Action onBuyerRejected,
        Action onIdExpired,
        Action onIdInvalid,
        Action onIdUnderage,
        Action onIdMismatch,
        Action onOther,
        Action<string> otherwise)
    {
        if (this == BuyerCanceled) onBuyerCanceled();
        else if (this == BuyerRejected) onBuyerRejected();
        else if (this == IdExpired) onIdExpired();
        else if (this == IdInvalid) onIdInvalid();
        else if (this == IdUnderage) onIdUnderage();
        else if (this == IdMismatch) onIdMismatch();
        else if (this == Other) onOther();
        else otherwise(Value);
    }
}
