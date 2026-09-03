using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<OrderItemDisposition>))]
public sealed record OrderItemDisposition : StringEnum<OrderItemDisposition>
{
    private OrderItemDisposition(string value) : base(value)
    {
    }

    public static readonly OrderItemDisposition Sellable = new("Sellable");

    public static readonly OrderItemDisposition Unsellable = new("Unsellable");

    public static OrderItemDisposition FromValue(string value) => FromValueCore(value);
}
