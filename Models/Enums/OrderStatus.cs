using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<OrderStatus>))]
public sealed record OrderStatus : StringEnum<OrderStatus>
{
    private OrderStatus(string value) : base(value)
    {
    }

    public static readonly OrderStatus Created = new("Created");

    public static readonly OrderStatus Acknowledged = new("Acknowledged");

    public static readonly OrderStatus Shipped = new("Shipped");

    public static readonly OrderStatus Delivered = new("Delivered");

    public static readonly OrderStatus Cancelled = new("Cancelled");

    public static readonly OrderStatus Refunded = new("Refunded");

    public static OrderStatus FromValue(string value) => FromValueCore(value);
}
