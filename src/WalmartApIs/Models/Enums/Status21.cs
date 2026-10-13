using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status21>))]
public sealed record Status21 : OpenStringEnum<Status21>
{
    private Status21(string value) : base(value)
    {
    }

    public static readonly Status21 Open = new("Open");

    public static readonly Status21 UnderReview = new("UnderReview");

    public static readonly Status21 Resolved = new("Resolved");

    public static readonly Status21 Closed = new("Closed");

    public TResult Match<TResult>(Func<TResult> onOpen,
        Func<TResult> onUnderReview,
        Func<TResult> onResolved,
        Func<TResult> onClosed,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Open => onOpen(),
            _ when this == UnderReview => onUnderReview(),
            _ when this == Resolved => onResolved(),
            _ when this == Closed => onClosed(),
            _ => otherwise(Value)
        };

    public void Match(Action onOpen, Action onUnderReview, Action onResolved, Action onClosed, Action<string> otherwise)
    {
        if (this == Open) onOpen();
        else if (this == UnderReview) onUnderReview();
        else if (this == Resolved) onResolved();
        else if (this == Closed) onClosed();
        else otherwise(Value);
    }
}
