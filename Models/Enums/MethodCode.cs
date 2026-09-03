using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<MethodCode>))]
public sealed record MethodCode : StringEnum<MethodCode>
{
    private MethodCode(string value) : base(value)
    {
    }

    public static readonly MethodCode Standard = new("Standard");

    public static readonly MethodCode Express = new("Express");

    public static readonly MethodCode SameDay = new("SameDay");

    public static readonly MethodCode Freight = new("Freight");

    public static MethodCode FromValue(string value) => FromValueCore(value);
}
