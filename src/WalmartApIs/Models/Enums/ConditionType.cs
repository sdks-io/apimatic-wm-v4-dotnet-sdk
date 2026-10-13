using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ConditionType>))]
public sealed record ConditionType : OpenStringEnum<ConditionType>
{
    private ConditionType(string value) : base(value)
    {
    }

    public static readonly ConditionType NewNew = new("new_new");

    public static readonly ConditionType UsedLikeNew = new("used_like_new");

    public static readonly ConditionType UsedVeryGood = new("used_very_good");

    public static readonly ConditionType UsedGood = new("used_good");

    public static readonly ConditionType UsedAcceptable = new("used_acceptable");

    public static readonly ConditionType CollectibleLikeNew = new("collectible_like_new");

    public static readonly ConditionType CollectibleVeryGood = new("collectible_very_good");

    public static readonly ConditionType CollectibleGood = new("collectible_good");

    public static readonly ConditionType CollectibleAcceptable = new("collectible_acceptable");

    public TResult Match<TResult>(Func<TResult> onNewNew,
        Func<TResult> onUsedLikeNew,
        Func<TResult> onUsedVeryGood,
        Func<TResult> onUsedGood,
        Func<TResult> onUsedAcceptable,
        Func<TResult> onCollectibleLikeNew,
        Func<TResult> onCollectibleVeryGood,
        Func<TResult> onCollectibleGood,
        Func<TResult> onCollectibleAcceptable,
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
        else otherwise(Value);
    }
}
