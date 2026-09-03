using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status5>))]
public sealed record Status5 : StringEnum<Status5>
{
    private Status5(string value) : base(value)
    {
    }

    public static readonly Status5 PreTransit = new("PRE_TRANSIT");

    public static readonly Status5 InTransit = new("IN_TRANSIT");

    public static readonly Status5 OutForDelivery = new("OUT_FOR_DELIVERY");

    public static readonly Status5 Delivered = new("DELIVERED");

    public static readonly Status5 Exception = new("EXCEPTION");

    public static readonly Status5 Returned = new("RETURNED");

    public static readonly Status5 Unknown = new("UNKNOWN");

    public static Status5 FromValue(string value) => FromValueCore(value);
}
