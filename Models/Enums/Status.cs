using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status>))]
public sealed record Status : StringEnum<Status>
{
    private Status(string value) : base(value)
    {
    }

    public static readonly Status Buyable = new("BUYABLE");

    public static readonly Status Suppressed = new("SUPPRESSED");

    public static readonly Status Discoverable = new("DISCOVERABLE");

    public static Status FromValue(string value) => FromValueCore(value);
}
