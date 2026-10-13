using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Unit of the weight being measured.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonUnitOfWeight>))]
public sealed record CommonUnitOfWeight : OpenStringEnum<CommonUnitOfWeight>
{
    private CommonUnitOfWeight(string value) : base(value)
    {
    }

    public static readonly CommonUnitOfWeight Lb = new("LB");

    public static readonly CommonUnitOfWeight Kg = new("KG");

    public TResult Match<TResult>(Func<TResult> onLb, Func<TResult> onKg, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Lb => onLb(),
            _ when this == Kg => onKg(),
            _ => otherwise(Value)
        };

    public void Match(Action onLb, Action onKg, Action<string> otherwise)
    {
        if (this == Lb) onLb();
        else if (this == Kg) onKg();
        else otherwise(Value);
    }
}
