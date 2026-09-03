using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status3>))]
public sealed record Status3 : StringEnum<Status3>
{
    private Status3(string value) : base(value)
    {
    }

    public static readonly Status3 Resolved = new("Resolved");

    public static readonly Status3 Closed = new("Closed");

    public static Status3 FromValue(string value) => FromValueCore(value);
}
