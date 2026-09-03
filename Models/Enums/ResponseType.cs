using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ResponseType>))]
public sealed record ResponseType : StringEnum<ResponseType>
{
    private ResponseType(string value) : base(value)
    {
    }

    public static readonly ResponseType Code = new("code");

    public static ResponseType FromValue(string value) => FromValueCore(value);
}
