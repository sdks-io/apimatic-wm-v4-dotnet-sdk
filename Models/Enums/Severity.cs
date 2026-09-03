using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Severity>))]
public sealed record Severity : StringEnum<Severity>
{
    private Severity(string value) : base(value)
    {
    }

    public static readonly Severity Error = new("ERROR");

    public static readonly Severity Warning = new("WARNING");

    public static readonly Severity Info = new("INFO");

    public static Severity FromValue(string value) => FromValueCore(value);
}
