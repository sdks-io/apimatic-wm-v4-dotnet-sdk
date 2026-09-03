using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<BuyerType>))]
public sealed record BuyerType : StringEnum<BuyerType>
{
    private BuyerType(string value) : base(value)
    {
    }

    public static readonly BuyerType B2B = new("B2B");

    public static readonly BuyerType B2C = new("B2C");

    public static readonly BuyerType All = new("All");

    public static BuyerType FromValue(string value) => FromValueCore(value);
}
