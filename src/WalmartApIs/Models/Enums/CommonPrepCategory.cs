using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The preparation category for shipping an item to Walmart's fulfillment network.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonPrepCategory>))]
public sealed record CommonPrepCategory : OpenStringEnum<CommonPrepCategory>
{
    private CommonPrepCategory(string value) : base(value)
    {
    }

    public static readonly CommonPrepCategory Adult = new("ADULT");

    public static readonly CommonPrepCategory Baby = new("BABY");

    public static readonly CommonPrepCategory FcProvided = new("FC_PROVIDED");

    public static readonly CommonPrepCategory Fragile = new("FRAGILE");

    public static readonly CommonPrepCategory Granular = new("GRANULAR");

    public static readonly CommonPrepCategory Hanger = new("HANGER");

    public static readonly CommonPrepCategory Liquid = new("LIQUID");

    public static readonly CommonPrepCategory Perforated = new("PERFORATED");

    public static readonly CommonPrepCategory Set = new("SET");

    public static readonly CommonPrepCategory Sharp = new("SHARP");

    public static readonly CommonPrepCategory Small = new("SMALL");

    public static readonly CommonPrepCategory Textile = new("TEXTILE");

    public static readonly CommonPrepCategory Unknown = new("UNKNOWN");

    public static readonly CommonPrepCategory None = new("NONE");

    public TResult Match<TResult>(Func<TResult> onAdult,
        Func<TResult> onBaby,
        Func<TResult> onFcProvided,
        Func<TResult> onFragile,
        Func<TResult> onGranular,
        Func<TResult> onHanger,
        Func<TResult> onLiquid,
        Func<TResult> onPerforated,
        Func<TResult> onSet,
        Func<TResult> onSharp,
        Func<TResult> onSmall,
        Func<TResult> onTextile,
        Func<TResult> onUnknown,
        Func<TResult> onNone,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Adult => onAdult(),
            _ when this == Baby => onBaby(),
            _ when this == FcProvided => onFcProvided(),
            _ when this == Fragile => onFragile(),
            _ when this == Granular => onGranular(),
            _ when this == Hanger => onHanger(),
            _ when this == Liquid => onLiquid(),
            _ when this == Perforated => onPerforated(),
            _ when this == Set => onSet(),
            _ when this == Sharp => onSharp(),
            _ when this == Small => onSmall(),
            _ when this == Textile => onTextile(),
            _ when this == Unknown => onUnknown(),
            _ when this == None => onNone(),
            _ => otherwise(Value)
        };

    public void Match(Action onAdult,
        Action onBaby,
        Action onFcProvided,
        Action onFragile,
        Action onGranular,
        Action onHanger,
        Action onLiquid,
        Action onPerforated,
        Action onSet,
        Action onSharp,
        Action onSmall,
        Action onTextile,
        Action onUnknown,
        Action onNone,
        Action<string> otherwise)
    {
        if (this == Adult) onAdult();
        else if (this == Baby) onBaby();
        else if (this == FcProvided) onFcProvided();
        else if (this == Fragile) onFragile();
        else if (this == Granular) onGranular();
        else if (this == Hanger) onHanger();
        else if (this == Liquid) onLiquid();
        else if (this == Perforated) onPerforated();
        else if (this == Set) onSet();
        else if (this == Sharp) onSharp();
        else if (this == Small) onSmall();
        else if (this == Textile) onTextile();
        else if (this == Unknown) onUnknown();
        else if (this == None) onNone();
        else otherwise(Value);
    }
}
