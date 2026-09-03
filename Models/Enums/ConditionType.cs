using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ConditionType>))]
public sealed record ConditionType : StringEnum<ConditionType>
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

    public static ConditionType FromValue(string value) => FromValueCore(value);
}
