using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedStatus>))]
public sealed record FeedStatus : OpenStringEnum<FeedStatus>
{
    private FeedStatus(string value) : base(value)
    {
    }

    public static readonly FeedStatus Received = new("RECEIVED");

    public static readonly FeedStatus InProgress = new("IN_PROGRESS");

    public static readonly FeedStatus Done = new("DONE");

    public static readonly FeedStatus Error = new("ERROR");

    public TResult Match<TResult>(Func<TResult> onReceived,
        Func<TResult> onInProgress,
        Func<TResult> onDone,
        Func<TResult> onError,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Received => onReceived(),
            _ when this == InProgress => onInProgress(),
            _ when this == Done => onDone(),
            _ when this == Error => onError(),
            _ => otherwise(Value)
        };

    public void Match(Action onReceived, Action onInProgress, Action onDone, Action onError, Action<string> otherwise)
    {
        if (this == Received) onReceived();
        else if (this == InProgress) onInProgress();
        else if (this == Done) onDone();
        else if (this == Error) onError();
        else otherwise(Value);
    }
}
