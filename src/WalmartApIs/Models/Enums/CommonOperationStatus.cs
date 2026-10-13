using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The status of an operation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonOperationStatus>))]
public sealed record CommonOperationStatus : OpenStringEnum<CommonOperationStatus>
{
    private CommonOperationStatus(string value) : base(value)
    {
    }

    public static readonly CommonOperationStatus Success = new("SUCCESS");

    public static readonly CommonOperationStatus Failed = new("FAILED");

    public static readonly CommonOperationStatus InProgress = new("IN_PROGRESS");

    public TResult Match<TResult>(Func<TResult> onSuccess,
        Func<TResult> onFailed,
        Func<TResult> onInProgress,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Success => onSuccess(),
            _ when this == Failed => onFailed(),
            _ when this == InProgress => onInProgress(),
            _ => otherwise(Value)
        };

    public void Match(Action onSuccess, Action onFailed, Action onInProgress, Action<string> otherwise)
    {
        if (this == Success) onSuccess();
        else if (this == Failed) onFailed();
        else if (this == InProgress) onInProgress();
        else otherwise(Value);
    }
}
