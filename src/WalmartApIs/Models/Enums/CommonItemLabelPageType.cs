using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The page type to use to print the labels.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonItemLabelPageType>))]
public sealed record CommonItemLabelPageType : OpenStringEnum<CommonItemLabelPageType>
{
    private CommonItemLabelPageType(string value) : base(value)
    {
    }

    public static readonly CommonItemLabelPageType A421 = new("A4_21");

    public static readonly CommonItemLabelPageType A424 = new("A4_24");

    public static readonly CommonItemLabelPageType A42464X33 = new("A4_24_64x33");

    public static readonly CommonItemLabelPageType A42466X35 = new("A4_24_66x35");

    public static readonly CommonItemLabelPageType A42470X36 = new("A4_24_70x36");

    public static readonly CommonItemLabelPageType A42470X37 = new("A4_24_70x37");

    public static readonly CommonItemLabelPageType A424I = new("A4_24i");

    public static readonly CommonItemLabelPageType A427 = new("A4_27");

    public static readonly CommonItemLabelPageType A44052X29 = new("A4_40_52x29");

    public static readonly CommonItemLabelPageType A44448X25 = new("A4_44_48x25");

    public static readonly CommonItemLabelPageType Letter30 = new("Letter_30");

    public TResult Match<TResult>(Func<TResult> onA421,
        Func<TResult> onA424,
        Func<TResult> onA42464X33,
        Func<TResult> onA42466X35,
        Func<TResult> onA42470X36,
        Func<TResult> onA42470X37,
        Func<TResult> onA424I,
        Func<TResult> onA427,
        Func<TResult> onA44052X29,
        Func<TResult> onA44448X25,
        Func<TResult> onLetter30,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == A421 => onA421(),
            _ when this == A424 => onA424(),
            _ when this == A42464X33 => onA42464X33(),
            _ when this == A42466X35 => onA42466X35(),
            _ when this == A42470X36 => onA42470X36(),
            _ when this == A42470X37 => onA42470X37(),
            _ when this == A424I => onA424I(),
            _ when this == A427 => onA427(),
            _ when this == A44052X29 => onA44052X29(),
            _ when this == A44448X25 => onA44448X25(),
            _ when this == Letter30 => onLetter30(),
            _ => otherwise(Value)
        };

    public void Match(Action onA421,
        Action onA424,
        Action onA42464X33,
        Action onA42466X35,
        Action onA42470X36,
        Action onA42470X37,
        Action onA424I,
        Action onA427,
        Action onA44052X29,
        Action onA44448X25,
        Action onLetter30,
        Action<string> otherwise)
    {
        if (this == A421) onA421();
        else if (this == A424) onA424();
        else if (this == A42464X33) onA42464X33();
        else if (this == A42466X35) onA42466X35();
        else if (this == A42470X36) onA42470X36();
        else if (this == A42470X37) onA42470X37();
        else if (this == A424I) onA424I();
        else if (this == A427) onA427();
        else if (this == A44052X29) onA44052X29();
        else if (this == A44448X25) onA44448X25();
        else if (this == Letter30) onLetter30();
        else otherwise(Value);
    }
}
