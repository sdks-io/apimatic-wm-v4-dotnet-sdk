using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Name of the add-on type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Name7>))]
public sealed record Name7 : OpenStringEnum<Name7>
{
    private Name7(string value) : base(value)
    {
    }

    public static readonly Name7 Signature = new("SIGNATURE");

    public static readonly Name7 Insurance = new("INSURANCE");

    public TResult Match<TResult>(Func<TResult> onSignature,
        Func<TResult> onInsurance,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Signature => onSignature(),
            _ when this == Insurance => onInsurance(),
            _ => otherwise(Value)
        };

    public void Match(Action onSignature, Action onInsurance, Action<string> otherwise)
    {
        if (this == Signature) onSignature();
        else if (this == Insurance) onInsurance();
        else otherwise(Value);
    }
}
