using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates the error type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type2>))]
public sealed record Type2 : OpenStringEnum<Type2>
{
    private Type2(string value) : base(value)
    {
    }

    public static readonly Type2 DataError = new("DATA_ERROR");

    public static readonly Type2 SystemError = new("SYSTEM_ERROR");

    public static readonly Type2 TimeoutError = new("TIMEOUT_ERROR");

    public TResult Match<TResult>(Func<TResult> onDataError,
        Func<TResult> onSystemError,
        Func<TResult> onTimeoutError,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == DataError => onDataError(),
            _ when this == SystemError => onSystemError(),
            _ when this == TimeoutError => onTimeoutError(),
            _ => otherwise(Value)
        };

    public void Match(Action onDataError, Action onSystemError, Action onTimeoutError, Action<string> otherwise)
    {
        if (this == DataError) onDataError();
        else if (this == SystemError) onSystemError();
        else if (this == TimeoutError) onTimeoutError();
        else otherwise(Value);
    }
}
