using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CancellationReason>))]
public sealed record CancellationReason : StringEnum<CancellationReason>
{
    private CancellationReason(string value) : base(value)
    {
    }

    public static readonly CancellationReason CustomerRequested = new("CUSTOMER_REQUESTED");

    public static readonly CancellationReason OutOfStock = new("OUT_OF_STOCK");

    public static readonly CancellationReason PriceError = new("PRICE_ERROR");

    public static readonly CancellationReason SellerInitiated = new("SELLER_INITIATED");

    public static CancellationReason FromValue(string value) => FromValueCore(value);
}
