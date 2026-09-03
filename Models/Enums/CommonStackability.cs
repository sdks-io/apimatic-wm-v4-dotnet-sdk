using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether pallets will be stacked when carrier arrives for pick-up.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonStackability>))]
public sealed record CommonStackability : StringEnum<CommonStackability>
{
    private CommonStackability(string value) : base(value)
    {
    }

    public static readonly CommonStackability Stackable = new("STACKABLE");

    public static readonly CommonStackability NonStackable = new("NON_STACKABLE");

    public static CommonStackability FromValue(string value) => FromValueCore(value);
}
