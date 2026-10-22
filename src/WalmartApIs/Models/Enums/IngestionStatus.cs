using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Can be one of the following: DATA_ERROR, SYSTEM_ERROR, TIMEOUT_ERROR, or INPROGRESS
/// </summary>
[JsonConverter(typeof(StringEnumConverter<IngestionStatus>))]
public sealed record IngestionStatus : OpenStringEnum<IngestionStatus>
{
    private IngestionStatus(string value) : base(value)
    {
    }

    public static readonly IngestionStatus Inprogress = new("INPROGRESS");

    public static readonly IngestionStatus Success = new("SUCCESS");

    public static readonly IngestionStatus DataError = new("DATA_ERROR");

    public static readonly IngestionStatus SystemError = new("SYSTEM_ERROR");

    public static readonly IngestionStatus TimeoutError = new("TIMEOUT_ERROR");

    public TResult Match<TResult>(Func<TResult> onInprogress,
        Func<TResult> onSuccess,
        Func<TResult> onDataError,
        Func<TResult> onSystemError,
        Func<TResult> onTimeoutError,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Inprogress => onInprogress(),
            _ when this == Success => onSuccess(),
            _ when this == DataError => onDataError(),
            _ when this == SystemError => onSystemError(),
            _ when this == TimeoutError => onTimeoutError(),
            _ => otherwise(Value)
        };

    public void Match(Action onInprogress,
        Action onSuccess,
        Action onDataError,
        Action onSystemError,
        Action onTimeoutError,
        Action<string> otherwise)
    {
        if (this == Inprogress) onInprogress();
        else if (this == Success) onSuccess();
        else if (this == DataError) onDataError();
        else if (this == SystemError) onSystemError();
        else if (this == TimeoutError) onTimeoutError();
        else otherwise(Value);
    }
}
