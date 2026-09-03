using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ConditionType1>))]
public sealed record ConditionType1 : StringEnum<ConditionType1>
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

    public static ConditionType1 FromValue(string value) => FromValueCore(value);
}
