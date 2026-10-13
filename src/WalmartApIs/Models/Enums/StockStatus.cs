using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Stock health label based on current days of supply.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<StockStatus>))]
public sealed record StockStatus : OpenStringEnum<StockStatus>
{
    private StockStatus(string value) : base(value)
    {
    }

    public static readonly StockStatus InStock = new("InStock");

    public static readonly StockStatus AtRisk = new("AtRisk");

    public static readonly StockStatus OutOfStock = new("OutOfStock");

    public static readonly StockStatus LongTermOutOfStock = new("LongTermOutOfStock");

    public static readonly StockStatus NewToWfs = new("NewToWfs");

    public TResult Match<TResult>(Func<TResult> onInStock,
        Func<TResult> onAtRisk,
        Func<TResult> onOutOfStock,
        Func<TResult> onLongTermOutOfStock,
        Func<TResult> onNewToWfs,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == InStock => onInStock(),
            _ when this == AtRisk => onAtRisk(),
            _ when this == OutOfStock => onOutOfStock(),
            _ when this == LongTermOutOfStock => onLongTermOutOfStock(),
            _ when this == NewToWfs => onNewToWfs(),
            _ => otherwise(Value)
        };

    public void Match(Action onInStock,
        Action onAtRisk,
        Action onOutOfStock,
        Action onLongTermOutOfStock,
        Action onNewToWfs,
        Action<string> otherwise)
    {
        if (this == InStock) onInStock();
        else if (this == AtRisk) onAtRisk();
        else if (this == OutOfStock) onOutOfStock();
        else if (this == LongTermOutOfStock) onLongTermOutOfStock();
        else if (this == NewToWfs) onNewToWfs();
        else otherwise(Value);
    }
}
