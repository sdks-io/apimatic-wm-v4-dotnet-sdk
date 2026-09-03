using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<NdrAction>))]
public sealed record NdrAction : StringEnum<NdrAction>
{
    private NdrAction(string value) : base(value)
    {
    }

    public static readonly NdrAction ReturnToOrigin = new("RETURN_TO_ORIGIN");

    public static readonly NdrAction ReattemptDelivery = new("REATTEMPT_DELIVERY");

    public static readonly NdrAction RedirectToAccessPoint = new("REDIRECT_TO_ACCESS_POINT");

    public static readonly NdrAction ContactBuyer = new("CONTACT_BUYER");

    public static NdrAction FromValue(string value) => FromValueCore(value);
}
