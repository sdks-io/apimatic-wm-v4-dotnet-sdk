using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status2>))]
public sealed record Status2 : StringEnum<Status2>
{
    private Status2(string value) : base(value)
    {
    }

    public static readonly Status2 Open = new("Open");

    public static readonly Status2 Closed = new("Closed");

    public static readonly Status2 Transferred = new("Transferred");

    public static Status2 FromValue(string value) => FromValueCore(value);
}
