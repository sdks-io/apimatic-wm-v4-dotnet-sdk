using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ItemType>))]
public sealed record ItemType : StringEnum<ItemType>
{
    private ItemType(string value) : base(value)
    {
    }

    public static readonly ItemType WalmartItemId = new("WalmartItemId");

    public static readonly ItemType Sku = new("Sku");

    public static ItemType FromValue(string value) => FromValueCore(value);
}
