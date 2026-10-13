using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Why the refund is being issued. Compressed from gmp-orders-mono's
/// 22-entry <c>RefundReason</c> enum to the three classes that actually
/// drive downstream behaviour today (return-flow vs cancel-flow vs
/// goodwill-credit). Free-form sub-reason goes in <c>reason</c>.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RefundType>))]
public sealed record RefundType : OpenStringEnum<RefundType>
{
    private RefundType(string value) : base(value)
    {
    }

    public static readonly RefundType Return = new("RETURN");

    public static readonly RefundType Cancellation = new("CANCELLATION");

    public static readonly RefundType Goodwill = new("GOODWILL");

    public TResult Match<TResult>(Func<TResult> onReturn,
        Func<TResult> onCancellation,
        Func<TResult> onGoodwill,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Return => onReturn(),
            _ when this == Cancellation => onCancellation(),
            _ when this == Goodwill => onGoodwill(),
            _ => otherwise(Value)
        };

    public void Match(Action onReturn, Action onCancellation, Action onGoodwill, Action<string> otherwise)
    {
        if (this == Return) onReturn();
        else if (this == Cancellation) onCancellation();
        else if (this == Goodwill) onGoodwill();
        else otherwise(Value);
    }
}
