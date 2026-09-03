using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ResponseType1>))]
public sealed record ResponseType1 : StringEnum<ResponseType1>
{
    private ResponseType1(string value) : base(value)
    {
    }

    public static readonly ResponseType1 Code = new("code");

    public static ResponseType1 FromValue(string value) => FromValueCore(value);
}
