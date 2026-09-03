using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FirstDayOfWeek>))]
public sealed record FirstDayOfWeek : StringEnum<FirstDayOfWeek>
{
    private FirstDayOfWeek(string value) : base(value)
    {
    }

    public static readonly FirstDayOfWeek Monday = new("Monday");

    public static readonly FirstDayOfWeek Sunday = new("Sunday");

    public static FirstDayOfWeek FromValue(string value) => FromValueCore(value);
}
