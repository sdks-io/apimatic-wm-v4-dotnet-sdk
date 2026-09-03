using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Stock health label based on current days of supply.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<StockStatus>))]
public sealed record StockStatus : StringEnum<StockStatus>
{
    private StockStatus(string value) : base(value)
    {
    }

    public static readonly StockStatus InStock = new("InStock");

    public static readonly StockStatus AtRisk = new("AtRisk");

    public static readonly StockStatus OutOfStock = new("OutOfStock");

    public static readonly StockStatus LongTermOutOfStock = new("LongTermOutOfStock");

    public static readonly StockStatus NewToWfs = new("NewToWfs");

    public static StockStatus FromValue(string value) => FromValueCore(value);
}
