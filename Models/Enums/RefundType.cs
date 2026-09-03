using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Why the refund is being issued. Compressed from gmp-orders-mono's
/// 22-entry <c>RefundReason</c> enum to the three classes that actually
/// drive downstream behaviour today (return-flow vs cancel-flow vs
/// goodwill-credit). Free-form sub-reason goes in <c>reason</c>.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RefundType>))]
public sealed record RefundType : StringEnum<RefundType>
{
    private RefundType(string value) : base(value)
    {
    }

    public static readonly RefundType Return = new("RETURN");

    public static readonly RefundType Cancellation = new("CANCELLATION");

    public static readonly RefundType Goodwill = new("GOODWILL");

    public static RefundType FromValue(string value) => FromValueCore(value);
}
