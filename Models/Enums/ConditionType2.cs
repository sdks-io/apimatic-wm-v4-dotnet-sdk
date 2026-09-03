using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates the condition of the item. Possible values: New, Used, Collectible, Refurbished, Club.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ConditionType2>))]
public sealed record ConditionType2 : StringEnum<ConditionType2>
{
    private ConditionType2(string value) : base(value)
    {
    }

    public static readonly ConditionType2 New = new("New");

    public static readonly ConditionType2 Used = new("Used");

    public static readonly ConditionType2 Collectible = new("Collectible");

    public static readonly ConditionType2 Refurbished = new("Refurbished");

    public static readonly ConditionType2 Club = new("Club");

    public static ConditionType2 FromValue(string value) => FromValueCore(value);
}
