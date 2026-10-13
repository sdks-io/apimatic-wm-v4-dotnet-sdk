using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Preparation instructions for shipping an item to Walmart's fulfillment network.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonPrepType>))]
public sealed record CommonPrepType : OpenStringEnum<CommonPrepType>
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

    public TResult Match<TResult>(Func<TResult> onItemBlackShrinkwrap,
        Func<TResult> onItemBlankstk,
        Func<TResult> onItemBoxing,
        Func<TResult> onItemBubblewrap,
        Func<TResult> onItemCapSealing,
        Func<TResult> onItemDebundle,
        Func<TResult> onItemHangGarment,
        Func<TResult> onItemLabeling,
        Func<TResult> onItemNoPrep,
        Func<TResult> onItemPolybagging,
        Func<TResult> onItemRmovhang,
        Func<TResult> onItemSetcreat,
        Func<TResult> onItemSetstk,
        Func<TResult> onItemSioc,
        Func<TResult> onItemSuffostk,
        Func<TResult> onItemTaping,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ItemBlackShrinkwrap => onItemBlackShrinkwrap(),
            _ when this == ItemBlankstk => onItemBlankstk(),
            _ when this == ItemBoxing => onItemBoxing(),
            _ when this == ItemBubblewrap => onItemBubblewrap(),
            _ when this == ItemCapSealing => onItemCapSealing(),
            _ when this == ItemDebundle => onItemDebundle(),
            _ when this == ItemHangGarment => onItemHangGarment(),
            _ when this == ItemLabeling => onItemLabeling(),
            _ when this == ItemNoPrep => onItemNoPrep(),
            _ when this == ItemPolybagging => onItemPolybagging(),
            _ when this == ItemRmovhang => onItemRmovhang(),
            _ when this == ItemSetcreat => onItemSetcreat(),
            _ when this == ItemSetstk => onItemSetstk(),
            _ when this == ItemSioc => onItemSioc(),
            _ when this == ItemSuffostk => onItemSuffostk(),
            _ when this == ItemTaping => onItemTaping(),
            _ => otherwise(Value)
        };

    public void Match(Action onItemBlackShrinkwrap,
        Action onItemBlankstk,
        Action onItemBoxing,
        Action onItemBubblewrap,
        Action onItemCapSealing,
        Action onItemDebundle,
        Action onItemHangGarment,
        Action onItemLabeling,
        Action onItemNoPrep,
        Action onItemPolybagging,
        Action onItemRmovhang,
        Action onItemSetcreat,
        Action onItemSetstk,
        Action onItemSioc,
        Action onItemSuffostk,
        Action onItemTaping,
        Action<string> otherwise)
    {
        if (this == ItemBlackShrinkwrap) onItemBlackShrinkwrap();
        else if (this == ItemBlankstk) onItemBlankstk();
        else if (this == ItemBoxing) onItemBoxing();
        else if (this == ItemBubblewrap) onItemBubblewrap();
        else if (this == ItemCapSealing) onItemCapSealing();
        else if (this == ItemDebundle) onItemDebundle();
        else if (this == ItemHangGarment) onItemHangGarment();
        else if (this == ItemLabeling) onItemLabeling();
        else if (this == ItemNoPrep) onItemNoPrep();
        else if (this == ItemPolybagging) onItemPolybagging();
        else if (this == ItemRmovhang) onItemRmovhang();
        else if (this == ItemSetcreat) onItemSetcreat();
        else if (this == ItemSetstk) onItemSetstk();
        else if (this == ItemSioc) onItemSioc();
        else if (this == ItemSuffostk) onItemSuffostk();
        else if (this == ItemTaping) onItemTaping();
        else otherwise(Value);
    }
}
