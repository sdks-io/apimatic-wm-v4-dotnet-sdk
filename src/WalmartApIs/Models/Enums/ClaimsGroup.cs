using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ClaimsGroup>))]
public sealed record ClaimsGroup : OpenStringEnum<ClaimsGroup>
{
    private ClaimsGroup(string value) : base(value)
    {
    }

    public static readonly ClaimsGroup Open = new("OPEN");

    public static readonly ClaimsGroup ActionNeeded = new("ACTION_NEEDED");

    public static readonly ClaimsGroup Closed = new("CLOSED");

    public TResult Match<TResult>(Func<TResult> onOpen,
        Func<TResult> onActionNeeded,
        Func<TResult> onClosed,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Open => onOpen(),
            _ when this == ActionNeeded => onActionNeeded(),
            _ when this == Closed => onClosed(),
            _ => otherwise(Value)
        };

    public void Match(Action onOpen, Action onActionNeeded, Action onClosed, Action<string> otherwise)
    {
        if (this == Open) onOpen();
        else if (this == ActionNeeded) onActionNeeded();
        else if (this == Closed) onClosed();
        else otherwise(Value);
    }
}
