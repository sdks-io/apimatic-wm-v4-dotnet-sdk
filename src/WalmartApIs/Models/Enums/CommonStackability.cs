using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether pallets will be stacked when carrier arrives for pick-up.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonStackability>))]
public sealed record CommonStackability : OpenStringEnum<CommonStackability>
{
    private CommonStackability(string value) : base(value)
    {
    }

    public static readonly CommonStackability Stackable = new("STACKABLE");

    public static readonly CommonStackability NonStackable = new("NON_STACKABLE");

    public TResult Match<TResult>(Func<TResult> onStackable,
        Func<TResult> onNonStackable,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Stackable => onStackable(),
            _ when this == NonStackable => onNonStackable(),
            _ => otherwise(Value)
        };

    public void Match(Action onStackable, Action onNonStackable, Action<string> otherwise)
    {
        if (this == Stackable) onStackable();
        else if (this == NonStackable) onNonStackable();
        else otherwise(Value);
    }
}
