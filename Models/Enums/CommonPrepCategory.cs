using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The preparation category for shipping an item to Walmart's fulfillment network.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonPrepCategory>))]
public sealed record CommonPrepCategory : StringEnum<CommonPrepCategory>
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

    public static CommonPrepCategory FromValue(string value) => FromValueCore(value);
}
