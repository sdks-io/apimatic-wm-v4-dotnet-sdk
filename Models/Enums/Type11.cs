using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Type11>))]
public sealed record Type11 : StringEnum<Type11>
{
    private Type11(string value) : base(value)
    {
    }

    public static readonly Type11 Pickup = new("PICKUP");

    public static readonly Type11 Dropoff = new("DROPOFF");

    public static Type11 FromValue(string value) => FromValueCore(value);
}
