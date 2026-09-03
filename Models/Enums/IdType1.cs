using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IdType1>))]
public sealed record IdType1 : StringEnum<IdType1>
{
    private IdType1(string value) : base(value)
    {
    }

    public static readonly IdType1 WalmartItemId = new("WalmartItemId");

    public static readonly IdType1 SellerSku = new("SellerSKU");

    public static IdType1 FromValue(string value) => FromValueCore(value);
}
