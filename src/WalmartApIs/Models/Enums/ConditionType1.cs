using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ConditionType1>))]
public sealed record ConditionType1 : OpenStringEnum<ConditionType1>
{
    private ConditionType1(string value) : base(value)
    {
    }

    public static readonly ConditionType1 NewNew = new("new_new");

    public static readonly ConditionType1 UsedLikeNew = new("used_like_new");

    public static readonly ConditionType1 UsedVeryGood = new("used_very_good");

    public static readonly ConditionType1 UsedGood = new("used_good");

    public static readonly ConditionType1 UsedAcceptable = new("used_acceptable");

    public static readonly ConditionType1 CollectibleLikeNew = new("collectible_like_new");

    public static readonly ConditionType1 CollectibleVeryGood = new("collectible_very_good");

    public static readonly ConditionType1 CollectibleGood = new("collectible_good");

    public static readonly ConditionType1 CollectibleAcceptable = new("collectible_acceptable");

    public static readonly ConditionType1 RefurbishedRefurbished = new("refurbished_refurbished");

    public TResult Match<TResult>(Func<TResult> onNewNew,
        Func<TResult> onUsedLikeNew,
        Func<TResult> onUsedVeryGood,
        Func<TResult> onUsedGood,
        Func<TResult> onUsedAcceptable,
        Func<TResult> onCollectibleLikeNew,
        Func<TResult> onCollectibleVeryGood,
        Func<TResult> onCollectibleGood,
        Func<TResult> onCollectibleAcceptable,
        Func<TResult> onRefurbishedRefurbished,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == NewNew => onNewNew(),
            _ when this == UsedLikeNew => onUsedLikeNew(),
            _ when this == UsedVeryGood => onUsedVeryGood(),
            _ when this == UsedGood => onUsedGood(),
            _ when this == UsedAcceptable => onUsedAcceptable(),
            _ when this == CollectibleLikeNew => onCollectibleLikeNew(),
            _ when this == CollectibleVeryGood => onCollectibleVeryGood(),
            _ when this == CollectibleGood => onCollectibleGood(),
            _ when this == CollectibleAcceptable => onCollectibleAcceptable(),
            _ when this == RefurbishedRefurbished => onRefurbishedRefurbished(),
            _ => otherwise(Value)
        };

    public void Match(Action onNewNew,
        Action onUsedLikeNew,
        Action onUsedVeryGood,
        Action onUsedGood,
        Action onUsedAcceptable,
        Action onCollectibleLikeNew,
        Action onCollectibleVeryGood,
        Action onCollectibleGood,
        Action onCollectibleAcceptable,
        Action onRefurbishedRefurbished,
        Action<string> otherwise)
    {
        if (this == NewNew) onNewNew();
        else if (this == UsedLikeNew) onUsedLikeNew();
        else if (this == UsedVeryGood) onUsedVeryGood();
        else if (this == UsedGood) onUsedGood();
        else if (this == UsedAcceptable) onUsedAcceptable();
        else if (this == CollectibleLikeNew) onCollectibleLikeNew();
        else if (this == CollectibleVeryGood) onCollectibleVeryGood();
        else if (this == CollectibleGood) onCollectibleGood();
        else if (this == CollectibleAcceptable) onCollectibleAcceptable();
        else if (this == RefurbishedRefurbished) onRefurbishedRefurbished();
        else otherwise(Value);
    }
}
