using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Severity level of the error.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Severity1>))]
public sealed record Severity1 : OpenStringEnum<Severity1>
{
    private Severity1(string value) : base(value)
    {
    }

    public static readonly Severity1 Emerg = new("EMERG");

    public static readonly Severity1 Alert = new("ALERT");

    public static readonly Severity1 Critical = new("CRITICAL");

    public static readonly Severity1 Error = new("ERROR");

    public static readonly Severity1 Warn = new("WARN");

    public TResult Match<TResult>(Func<TResult> onEmerg,
        Func<TResult> onAlert,
        Func<TResult> onCritical,
        Func<TResult> onError,
        Func<TResult> onWarn,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Emerg => onEmerg(),
            _ when this == Alert => onAlert(),
            _ when this == Critical => onCritical(),
            _ when this == Error => onError(),
            _ when this == Warn => onWarn(),
            _ => otherwise(Value)
        };

    public void Match(Action onEmerg,
        Action onAlert,
        Action onCritical,
        Action onError,
        Action onWarn,
        Action<string> otherwise)
    {
        if (this == Emerg) onEmerg();
        else if (this == Alert) onAlert();
        else if (this == Critical) onCritical();
        else if (this == Error) onError();
        else if (this == Warn) onWarn();
        else otherwise(Value);
    }
}
