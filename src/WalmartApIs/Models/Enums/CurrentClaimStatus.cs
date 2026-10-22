using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CurrentClaimStatus>))]
public sealed record CurrentClaimStatus : OpenStringEnum<CurrentClaimStatus>
{
    private CurrentClaimStatus(string value) : base(value)
    {
    }

    public static readonly CurrentClaimStatus Initiated = new("INITIATED");

    public static readonly CurrentClaimStatus InReview = new("IN_REVIEW");

    public static readonly CurrentClaimStatus NeedInfo = new("NEED_INFO");

    public static readonly CurrentClaimStatus Approved = new("APPROVED");

    public static readonly CurrentClaimStatus PaymentInitiated = new("PAYMENT_INITIATED");

    public static readonly CurrentClaimStatus PaidOut = new("PAID_OUT");

    public static readonly CurrentClaimStatus Rejected = new("REJECTED");

    public TResult Match<TResult>(Func<TResult> onInitiated,
        Func<TResult> onInReview,
        Func<TResult> onNeedInfo,
        Func<TResult> onApproved,
        Func<TResult> onPaymentInitiated,
        Func<TResult> onPaidOut,
        Func<TResult> onRejected,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Initiated => onInitiated(),
            _ when this == InReview => onInReview(),
            _ when this == NeedInfo => onNeedInfo(),
            _ when this == Approved => onApproved(),
            _ when this == PaymentInitiated => onPaymentInitiated(),
            _ when this == PaidOut => onPaidOut(),
            _ when this == Rejected => onRejected(),
            _ => otherwise(Value)
        };

    public void Match(Action onInitiated,
        Action onInReview,
        Action onNeedInfo,
        Action onApproved,
        Action onPaymentInitiated,
        Action onPaidOut,
        Action onRejected,
        Action<string> otherwise)
    {
        if (this == Initiated) onInitiated();
        else if (this == InReview) onInReview();
        else if (this == NeedInfo) onNeedInfo();
        else if (this == Approved) onApproved();
        else if (this == PaymentInitiated) onPaymentInitiated();
        else if (this == PaidOut) onPaidOut();
        else if (this == Rejected) onRejected();
        else otherwise(Value);
    }
}
