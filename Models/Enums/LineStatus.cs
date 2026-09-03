using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<LineStatus>))]
public sealed record LineStatus : StringEnum<LineStatus>
{
    private LineStatus(string value) : base(value)
    {
    }

    public static readonly LineStatus Created = new("Created");

    public static readonly LineStatus Acknowledged = new("Acknowledged");

    public static readonly LineStatus Shipped = new("Shipped");

    public static readonly LineStatus Delivered = new("Delivered");

    public static readonly LineStatus Cancelled = new("Cancelled");

    public static readonly LineStatus Refunded = new("Refunded");

    public static LineStatus FromValue(string value) => FromValueCore(value);
}
