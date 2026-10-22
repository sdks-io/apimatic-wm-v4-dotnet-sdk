using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Decision>))]
public sealed record Decision : OpenStringEnum<Decision>
{
    private Decision(string value) : base(value)
    {
    }

    public static readonly Decision Rejected = new("REJECTED");

    public static readonly Decision Approved = new("APPROVED");

    public TResult Match<TResult>(Func<TResult> onRejected,
        Func<TResult> onApproved,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Rejected => onRejected(),
            _ when this == Approved => onApproved(),
            _ => otherwise(Value)
        };

    public void Match(Action onRejected, Action onApproved, Action<string> otherwise)
    {
        if (this == Rejected) onRejected();
        else if (this == Approved) onApproved();
        else otherwise(Value);
    }
}
