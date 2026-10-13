using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<NdrAction>))]
public sealed record NdrAction : OpenStringEnum<NdrAction>
{
    private NdrAction(string value) : base(value)
    {
    }

    public static readonly NdrAction ReturnToOrigin = new("RETURN_TO_ORIGIN");

    public static readonly NdrAction ReattemptDelivery = new("REATTEMPT_DELIVERY");

    public static readonly NdrAction RedirectToAccessPoint = new("REDIRECT_TO_ACCESS_POINT");

    public static readonly NdrAction ContactBuyer = new("CONTACT_BUYER");

    public TResult Match<TResult>(Func<TResult> onReturnToOrigin,
        Func<TResult> onReattemptDelivery,
        Func<TResult> onRedirectToAccessPoint,
        Func<TResult> onContactBuyer,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ReturnToOrigin => onReturnToOrigin(),
            _ when this == ReattemptDelivery => onReattemptDelivery(),
            _ when this == RedirectToAccessPoint => onRedirectToAccessPoint(),
            _ when this == ContactBuyer => onContactBuyer(),
            _ => otherwise(Value)
        };

    public void Match(Action onReturnToOrigin,
        Action onReattemptDelivery,
        Action onRedirectToAccessPoint,
        Action onContactBuyer,
        Action<string> otherwise)
    {
        if (this == ReturnToOrigin) onReturnToOrigin();
        else if (this == ReattemptDelivery) onReattemptDelivery();
        else if (this == RedirectToAccessPoint) onRedirectToAccessPoint();
        else if (this == ContactBuyer) onContactBuyer();
        else otherwise(Value);
    }
}
