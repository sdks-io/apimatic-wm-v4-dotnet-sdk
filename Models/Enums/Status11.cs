using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status11>))]
public sealed record Status11 : StringEnum<Status11>
{
    private Status11(string value) : base(value)
    {
    }

    public static readonly Status11 Pending = new("Pending");

    public static readonly Status11 Processing = new("Processing");

    public static readonly Status11 Completed = new("Completed");

    public static readonly Status11 Failed = new("Failed");

    public static readonly Status11 OnHold = new("OnHold");

    public static Status11 FromValue(string value) => FromValueCore(value);
}
