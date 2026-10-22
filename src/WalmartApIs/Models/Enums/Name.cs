using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Name of the AddOn type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Name>))]
public sealed record Name : OpenStringEnum<Name>
{
    private Name(string value) : base(value)
    {
    }

    public static readonly Name Signature = new("SIGNATURE");

    public static readonly Name Insurance = new("INSURANCE");

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
