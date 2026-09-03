using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status1>))]
public sealed record Status1 : StringEnum<Status1>
{
    private Status1(string value) : base(value)
    {
    }

    public static readonly Status1 Accepted = new("ACCEPTED");

    public static readonly Status1 Invalid = new("INVALID");

    public static Status1 FromValue(string value) => FromValueCore(value);
}
