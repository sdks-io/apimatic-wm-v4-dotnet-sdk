using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status21>))]
public sealed record Status21 : StringEnum<Status21>
{
    private Status21(string value) : base(value)
    {
    }

    public static readonly Status21 Open = new("Open");

    public static readonly Status21 UnderReview = new("UnderReview");

    public static readonly Status21 Resolved = new("Resolved");

    public static readonly Status21 Closed = new("Closed");

    public static Status21 FromValue(string value) => FromValueCore(value);
}
