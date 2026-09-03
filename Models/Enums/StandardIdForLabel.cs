using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<StandardIdForLabel>))]
public sealed record StandardIdForLabel : StringEnum<StandardIdForLabel>
{
    private StandardIdForLabel(string value) : base(value)
    {
    }

    public static readonly StandardIdForLabel WalmartOrderId = new("WalmartOrderId");

    public static StandardIdForLabel FromValue(string value) => FromValueCore(value);
}
