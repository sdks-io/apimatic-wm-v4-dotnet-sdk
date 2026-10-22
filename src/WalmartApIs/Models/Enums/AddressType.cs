using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Type of address to which shipping has to be covered as part of mentioned region, sub region and states.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AddressType>))]
public sealed record AddressType : OpenStringEnum<AddressType>
{
    private AddressType(string value) : base(value)
    {
    }

    public static readonly AddressType PoBox = new("PO_BOX");

    public static readonly AddressType Military = new("MILITARY");

    public static readonly AddressType Street = new("STREET");

    public TResult Match<TResult>(Func<TResult> onPoBox,
        Func<TResult> onMilitary,
        Func<TResult> onStreet,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == PoBox => onPoBox(),
            _ when this == Military => onMilitary(),
            _ when this == Street => onStreet(),
            _ => otherwise(Value)
        };

    public void Match(Action onPoBox, Action onMilitary, Action onStreet, Action<string> otherwise)
    {
        if (this == PoBox) onPoBox();
        else if (this == Military) onMilitary();
        else if (this == Street) onStreet();
        else otherwise(Value);
    }
}
