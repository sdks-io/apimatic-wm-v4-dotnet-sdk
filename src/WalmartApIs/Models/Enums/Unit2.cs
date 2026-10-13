using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Unit2>))]
public sealed record Unit2 : OpenStringEnum<Unit2>
{
    private Unit2(string value) : base(value)
    {
    }

    public static readonly Unit2 Ea = new("EA");

    public static readonly Unit2 Each = new("EACH");

    public static readonly Unit2 Case = new("CASE");

    public static readonly Unit2 Carton = new("CARTON");

    public TResult Match<TResult>(Func<TResult> onEa,
        Func<TResult> onEach,
        Func<TResult> onCase,
        Func<TResult> onCarton,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Ea => onEa(),
            _ when this == Each => onEach(),
            _ when this == Case => onCase(),
            _ when this == Carton => onCarton(),
            _ => otherwise(Value)
        };

    public void Match(Action onEa, Action onEach, Action onCase, Action onCarton, Action<string> otherwise)
    {
        if (this == Ea) onEa();
        else if (this == Each) onEach();
        else if (this == Case) onCase();
        else if (this == Carton) onCarton();
        else otherwise(Value);
    }
}
