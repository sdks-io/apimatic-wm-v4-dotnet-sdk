using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CancellationStatus>))]
public sealed record CancellationStatus : OpenStringEnum<CancellationStatus>
{
    private CancellationStatus(string value) : base(value)
    {
    }

    public static readonly CancellationStatus Cancelled = new("CANCELLED");

    public static readonly CancellationStatus Pending = new("PENDING");

    public static readonly CancellationStatus Rejected = new("REJECTED");

    public TResult Match<TResult>(Func<TResult> onCancelled,
        Func<TResult> onPending,
        Func<TResult> onRejected,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Cancelled => onCancelled(),
            _ when this == Pending => onPending(),
            _ when this == Rejected => onRejected(),
            _ => otherwise(Value)
        };

    public void Match(Action onCancelled, Action onPending, Action onRejected, Action<string> otherwise)
    {
        if (this == Cancelled) onCancelled();
        else if (this == Pending) onPending();
        else if (this == Rejected) onRejected();
        else otherwise(Value);
    }
}
