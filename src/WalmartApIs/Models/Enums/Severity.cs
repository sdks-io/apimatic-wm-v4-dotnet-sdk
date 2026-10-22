using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Severity>))]
public sealed record Severity : OpenStringEnum<Severity>
{
    private Severity(string value) : base(value)
    {
    }

    public static readonly Severity Info = new("INFO");

    public static readonly Severity Warn = new("WARN");

    public static readonly Severity Error = new("ERROR");

    public TResult Match<TResult>(Func<TResult> onInfo,
        Func<TResult> onWarn,
        Func<TResult> onError,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Info => onInfo(),
            _ when this == Warn => onWarn(),
            _ when this == Error => onError(),
            _ => otherwise(Value)
        };

    public void Match(Action onInfo, Action onWarn, Action onError, Action<string> otherwise)
    {
        if (this == Info) onInfo();
        else if (this == Warn) onWarn();
        else if (this == Error) onError();
        else otherwise(Value);
    }
}
