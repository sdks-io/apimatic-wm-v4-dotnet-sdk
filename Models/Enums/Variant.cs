using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Variant>))]
public sealed record Variant : StringEnum<Variant>
{
    private Variant(string value) : base(value)
    {
    }

    public static readonly Variant Main = new("MAIN");

    public static readonly Variant Pt01 = new("PT01");

    public static readonly Variant Pt02 = new("PT02");

    public static readonly Variant Pt03 = new("PT03");

    public static readonly Variant Pt04 = new("PT04");

    public static readonly Variant Swch = new("SWCH");

    public static Variant FromValue(string value) => FromValueCore(value);
}
