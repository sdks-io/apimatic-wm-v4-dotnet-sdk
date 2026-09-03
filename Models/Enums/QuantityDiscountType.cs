using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates the type of quantity discount this price applies to.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<QuantityDiscountType>))]
public sealed record QuantityDiscountType : StringEnum<QuantityDiscountType>
{
    private QuantityDiscountType(string value) : base(value)
    {
    }

    public static readonly QuantityDiscountType QuantityDiscount = new("QUANTITY_DISCOUNT");

    public static QuantityDiscountType FromValue(string value) => FromValueCore(value);
}
