using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(IntEnumConverter<Dpi>))]
public sealed record Dpi : IntEnum<Dpi>
{
    private Dpi(int value) : base(value)
    {
    }

    public static readonly Dpi Value203 = new(203);

    public static readonly Dpi Value300 = new(300);

    public static Dpi FromValue(int value) => FromValueCore(value);
}
