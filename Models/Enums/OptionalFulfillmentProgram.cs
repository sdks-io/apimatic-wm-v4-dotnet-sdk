using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Optional fulfillment program override for WFS items.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OptionalFulfillmentProgram>))]
public sealed record OptionalFulfillmentProgram : StringEnum<OptionalFulfillmentProgram>
{
    private OptionalFulfillmentProgram(string value) : base(value)
    {
    }

    public static readonly OptionalFulfillmentProgram WfsStandard = new("WFS_STANDARD");

    public static readonly OptionalFulfillmentProgram WfsExpedited = new("WFS_EXPEDITED");

    public static OptionalFulfillmentProgram FromValue(string value) => FromValueCore(value);
}
