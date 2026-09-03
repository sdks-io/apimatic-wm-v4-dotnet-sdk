using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The page type to use to print the labels.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonItemLabelPageType>))]
public sealed record CommonItemLabelPageType : StringEnum<CommonItemLabelPageType>
{
    private CommonItemLabelPageType(string value) : base(value)
    {
    }

    public static readonly CommonItemLabelPageType A421 = new("A4_21");

    public static readonly CommonItemLabelPageType A424 = new("A4_24");

    public static readonly CommonItemLabelPageType A42464X33 = new("A4_24_64x33");

    public static readonly CommonItemLabelPageType A42466X35 = new("A4_24_66x35");

    public static readonly CommonItemLabelPageType A42470X36 = new("A4_24_70x36");

    public static readonly CommonItemLabelPageType A42470X37 = new("A4_24_70x37");

    public static readonly CommonItemLabelPageType A424I = new("A4_24i");

    public static readonly CommonItemLabelPageType A427 = new("A4_27");

    public static readonly CommonItemLabelPageType A44052X29 = new("A4_40_52x29");

    public static readonly CommonItemLabelPageType A44448X25 = new("A4_44_48x25");

    public static readonly CommonItemLabelPageType Letter30 = new("Letter_30");

    public static CommonItemLabelPageType FromValue(string value) => FromValueCore(value);
}
