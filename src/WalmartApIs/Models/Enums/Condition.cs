using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Item condition.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Condition>))]
public sealed record Condition : OpenStringEnum<Condition>
{
    private Condition(string value) : base(value)
    {
    }

    public static readonly Condition NewItem = new("NewItem");

    public static readonly Condition UsedLikeNew = new("UsedLikeNew");

    public static readonly Condition UsedVeryGood = new("UsedVeryGood");

    public static readonly Condition UsedGood = new("UsedGood");

    public static readonly Condition UsedAcceptable = new("UsedAcceptable");

    public static readonly Condition CollectibleLikeNew = new("CollectibleLikeNew");

    public static readonly Condition CollectibleVeryGood = new("CollectibleVeryGood");

    public static readonly Condition CollectibleGood = new("CollectibleGood");

    public static readonly Condition CollectibleAcceptable = new("CollectibleAcceptable");

    public static readonly Condition RefurbishedWithWarranty = new("RefurbishedWithWarranty");

    public static readonly Condition Refurbished = new("Refurbished");

    public static readonly Condition ClubItem = new("ClubItem");

    public TResult Match<TResult>(Func<TResult> onNewItem,
        Func<TResult> onUsedLikeNew,
        Func<TResult> onUsedVeryGood,
        Func<TResult> onUsedGood,
        Func<TResult> onUsedAcceptable,
        Func<TResult> onCollectibleLikeNew,
        Func<TResult> onCollectibleVeryGood,
        Func<TResult> onCollectibleGood,
        Func<TResult> onCollectibleAcceptable,
        Func<TResult> onRefurbishedWithWarranty,
        Func<TResult> onRefurbished,
        Func<TResult> onClubItem,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == NewItem => onNewItem(),
            _ when this == UsedLikeNew => onUsedLikeNew(),
            _ when this == UsedVeryGood => onUsedVeryGood(),
            _ when this == UsedGood => onUsedGood(),
            _ when this == UsedAcceptable => onUsedAcceptable(),
            _ when this == CollectibleLikeNew => onCollectibleLikeNew(),
            _ when this == CollectibleVeryGood => onCollectibleVeryGood(),
            _ when this == CollectibleGood => onCollectibleGood(),
            _ when this == CollectibleAcceptable => onCollectibleAcceptable(),
            _ when this == RefurbishedWithWarranty => onRefurbishedWithWarranty(),
            _ when this == Refurbished => onRefurbished(),
            _ when this == ClubItem => onClubItem(),
            _ => otherwise(Value)
        };

    public void Match(Action onNewItem,
        Action onUsedLikeNew,
        Action onUsedVeryGood,
        Action onUsedGood,
        Action onUsedAcceptable,
        Action onCollectibleLikeNew,
        Action onCollectibleVeryGood,
        Action onCollectibleGood,
        Action onCollectibleAcceptable,
        Action onRefurbishedWithWarranty,
        Action onRefurbished,
        Action onClubItem,
        Action<string> otherwise)
    {
        if (this == NewItem) onNewItem();
        else if (this == UsedLikeNew) onUsedLikeNew();
        else if (this == UsedVeryGood) onUsedVeryGood();
        else if (this == UsedGood) onUsedGood();
        else if (this == UsedAcceptable) onUsedAcceptable();
        else if (this == CollectibleLikeNew) onCollectibleLikeNew();
        else if (this == CollectibleVeryGood) onCollectibleVeryGood();
        else if (this == CollectibleGood) onCollectibleGood();
        else if (this == CollectibleAcceptable) onCollectibleAcceptable();
        else if (this == RefurbishedWithWarranty) onRefurbishedWithWarranty();
        else if (this == Refurbished) onRefurbished();
        else if (this == ClubItem) onClubItem();
        else otherwise(Value);
    }
}
