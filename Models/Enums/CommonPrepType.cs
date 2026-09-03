using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Preparation instructions for shipping an item to Walmart's fulfillment network.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonPrepType>))]
public sealed record CommonPrepType : StringEnum<CommonPrepType>
{
    private CommonPrepType(string value) : base(value)
    {
    }

    public static readonly CommonPrepType ItemBlackShrinkwrap = new("ITEM_BLACK_SHRINKWRAP");

    public static readonly CommonPrepType ItemBlankstk = new("ITEM_BLANKSTK");

    public static readonly CommonPrepType ItemBoxing = new("ITEM_BOXING");

    public static readonly CommonPrepType ItemBubblewrap = new("ITEM_BUBBLEWRAP");

    public static readonly CommonPrepType ItemCapSealing = new("ITEM_CAP_SEALING");

    public static readonly CommonPrepType ItemDebundle = new("ITEM_DEBUNDLE");

    public static readonly CommonPrepType ItemHangGarment = new("ITEM_HANG_GARMENT");

    public static readonly CommonPrepType ItemLabeling = new("ITEM_LABELING");

    public static readonly CommonPrepType ItemNoPrep = new("ITEM_NO_PREP");

    public static readonly CommonPrepType ItemPolybagging = new("ITEM_POLYBAGGING");

    public static readonly CommonPrepType ItemRmovhang = new("ITEM_RMOVHANG");

    public static readonly CommonPrepType ItemSetcreat = new("ITEM_SETCREAT");

    public static readonly CommonPrepType ItemSetstk = new("ITEM_SETSTK");

    public static readonly CommonPrepType ItemSioc = new("ITEM_SIOC");

    public static readonly CommonPrepType ItemSuffostk = new("ITEM_SUFFOSTK");

    public static readonly CommonPrepType ItemTaping = new("ITEM_TAPING");

    public static CommonPrepType FromValue(string value) => FromValueCore(value);
}
