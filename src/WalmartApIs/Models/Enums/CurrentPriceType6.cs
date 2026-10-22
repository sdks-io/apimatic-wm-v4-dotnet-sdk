using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CurrentPriceType6>))]
public sealed record CurrentPriceType6 : OpenStringEnum<CurrentPriceType6>
{
    private CurrentPriceType6(string value) : base(value)
    {
    }

    public static readonly CurrentPriceType6 Base = new("BASE");

    public static readonly CurrentPriceType6 Reduced = new("REDUCED");

    public static readonly CurrentPriceType6 SavingsAmt = new("SAVINGS_AMT");

    public static readonly CurrentPriceType6 SavingsPct = new("SAVINGS_PCT");

    public static readonly CurrentPriceType6 Rollback = new("ROLLBACK");

    public static readonly CurrentPriceType6 Clearance = new("CLEARANCE");

    public static readonly CurrentPriceType6 ListPrice = new("LIST_PRICE");

    public TResult Match<TResult>(Func<TResult> onBase,
        Func<TResult> onReduced,
        Func<TResult> onSavingsAmt,
        Func<TResult> onSavingsPct,
        Func<TResult> onRollback,
        Func<TResult> onClearance,
        Func<TResult> onListPrice,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Base => onBase(),
            _ when this == Reduced => onReduced(),
            _ when this == SavingsAmt => onSavingsAmt(),
            _ when this == SavingsPct => onSavingsPct(),
            _ when this == Rollback => onRollback(),
            _ when this == Clearance => onClearance(),
            _ when this == ListPrice => onListPrice(),
            _ => otherwise(Value)
        };

    public void Match(Action onBase,
        Action onReduced,
        Action onSavingsAmt,
        Action onSavingsPct,
        Action onRollback,
        Action onClearance,
        Action onListPrice,
        Action<string> otherwise)
    {
        if (this == Base) onBase();
        else if (this == Reduced) onReduced();
        else if (this == SavingsAmt) onSavingsAmt();
        else if (this == SavingsPct) onSavingsPct();
        else if (this == Rollback) onRollback();
        else if (this == Clearance) onClearance();
        else if (this == ListPrice) onListPrice();
        else otherwise(Value);
    }
}
