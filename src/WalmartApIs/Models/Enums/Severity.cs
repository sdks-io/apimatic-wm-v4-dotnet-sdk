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

    public static readonly Severity Error = new("ERROR");

    public static readonly Severity Warning = new("WARNING");

    public static readonly Severity Info = new("INFO");

    public TResult Match<TResult>(Func<TResult> onError,
        Func<TResult> onWarning,
        Func<TResult> onInfo,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Error => onError(),
            _ when this == Warning => onWarning(),
            _ when this == Info => onInfo(),
            _ => otherwise(Value)
        };

    public void Match(Action onError, Action onWarning, Action onInfo, Action<string> otherwise)
    {
        if (this == Error) onError();
        else if (this == Warning) onWarning();
        else if (this == Info) onInfo();
        else otherwise(Value);
    }
}
