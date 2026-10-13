using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Current processing status of the feed
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ProcessingStatus1>))]
public sealed record ProcessingStatus1 : OpenStringEnum<ProcessingStatus1>
{
    private ProcessingStatus1(string value) : base(value)
    {
    }

    public static readonly ProcessingStatus1 Received = new("RECEIVED");

    public static readonly ProcessingStatus1 InProgress = new("IN_PROGRESS");

    public static readonly ProcessingStatus1 Done = new("DONE");

    public static readonly ProcessingStatus1 Error = new("ERROR");

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
