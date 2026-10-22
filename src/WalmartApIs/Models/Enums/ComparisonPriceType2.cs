using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ComparisonPriceType2>))]
public sealed record ComparisonPriceType2 : OpenStringEnum<ComparisonPriceType2>
{
    private ComparisonPriceType2(string value) : base(value)
    {
    }

    public static readonly ComparisonPriceType2 Base = new("BASE");

    public static readonly ComparisonPriceType2 Reduced = new("REDUCED");

    public static readonly ComparisonPriceType2 SavingsAmt = new("SAVINGS_AMT");

    public static readonly ComparisonPriceType2 SavingsPct = new("SAVINGS_PCT");

    public static readonly ComparisonPriceType2 Rollback = new("ROLLBACK");

    public static readonly ComparisonPriceType2 Clearance = new("CLEARANCE");

    public static readonly ComparisonPriceType2 ListPrice = new("LIST_PRICE");

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
