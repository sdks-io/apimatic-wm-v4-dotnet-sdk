using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Unit1>))]
public sealed record Unit1 : StringEnum<Unit1>
{
    private Unit1(string value) : base(value)
    {
    }

    public static readonly Unit1 Oz = new("oz");

    public static readonly Unit1 G = new("g");

    public static readonly Unit1 Lb = new("lb");

    public static readonly Unit1 Kg = new("kg");

    public static Unit1 FromValue(string value) => FromValueCore(value);
}
