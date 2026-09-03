using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Item condition.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Condition>))]
public sealed record Condition : StringEnum<Condition>
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

    public static Condition FromValue(string value) => FromValueCore(value);
}
