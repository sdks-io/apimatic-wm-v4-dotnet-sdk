using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<VerificationStatus1>))]
public sealed record VerificationStatus1 : OpenStringEnum<VerificationStatus1>
{
    private VerificationStatus1(string value) : base(value)
    {
    }

    public static readonly VerificationStatus1 Approved = new("APPROVED");

    public static readonly VerificationStatus1 Rejected = new("REJECTED");

    public TResult Match<TResult>(Func<TResult> onApproved,
        Func<TResult> onRejected,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Approved => onApproved(),
            _ when this == Rejected => onRejected(),
            _ => otherwise(Value)
        };

    public void Match(Action onApproved, Action onRejected, Action<string> otherwise)
    {
        if (this == Approved) onApproved();
        else if (this == Rejected) onRejected();
        else otherwise(Value);
    }
}
