using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates the condition of the item. Possible values: New, Used, Collectible, Refurbished, Club.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ConditionType2>))]
public sealed record ConditionType2 : OpenStringEnum<ConditionType2>
{
    private ConditionType2(string value) : base(value)
    {
    }

    public static readonly ConditionType2 New = new("New");

    public static readonly ConditionType2 Used = new("Used");

    public static readonly ConditionType2 Collectible = new("Collectible");

    public static readonly ConditionType2 Refurbished = new("Refurbished");

    public static readonly ConditionType2 Club = new("Club");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onUsed,
        Func<TResult> onCollectible,
        Func<TResult> onRefurbished,
        Func<TResult> onClub,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Used => onUsed(),
            _ when this == Collectible => onCollectible(),
            _ when this == Refurbished => onRefurbished(),
            _ when this == Club => onClub(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew,
        Action onUsed,
        Action onCollectible,
        Action onRefurbished,
        Action onClub,
        Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Used) onUsed();
        else if (this == Collectible) onCollectible();
        else if (this == Refurbished) onRefurbished();
        else if (this == Club) onClub();
        else otherwise(Value);
    }
}
