using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<TypeEnum>))]
public sealed record TypeEnum : StringEnum<TypeEnum>
{
    private TypeEnum(string value) : base(value)
    {
    }

    public static readonly TypeEnum Variation = new("VARIATION");

    public static readonly TypeEnum Accessory = new("ACCESSORY");

    public static readonly TypeEnum BundleComponent = new("BUNDLE_COMPONENT");

    public static TypeEnum FromValue(string value) => FromValueCore(value);
}
