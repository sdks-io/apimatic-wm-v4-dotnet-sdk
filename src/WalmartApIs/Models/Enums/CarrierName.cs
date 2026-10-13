using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CarrierName>))]
public sealed record CarrierName : OpenStringEnum<CarrierName>
{
    private CarrierName(string value) : base(value)
    {
    }

    public static readonly CarrierName Ups = new("UPS");

    public static readonly CarrierName Usps = new("USPS");

    public static readonly CarrierName FedEx = new("FedEx");

    public static readonly CarrierName OnTrac = new("OnTrac");

    public static readonly CarrierName LaserShip = new("LaserShip");

    public static readonly CarrierName WalmartGround = new("WALMART_GROUND");

    public static readonly CarrierName Other = new("OTHER");

    public TResult Match<TResult>(Func<TResult> onUps,
        Func<TResult> onUsps,
        Func<TResult> onFedEx,
        Func<TResult> onOnTrac,
        Func<TResult> onLaserShip,
        Func<TResult> onWalmartGround,
        Func<TResult> onOther,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Ups => onUps(),
            _ when this == Usps => onUsps(),
            _ when this == FedEx => onFedEx(),
            _ when this == OnTrac => onOnTrac(),
            _ when this == LaserShip => onLaserShip(),
            _ when this == WalmartGround => onWalmartGround(),
            _ when this == Other => onOther(),
            _ => otherwise(Value)
        };

    public void Match(Action onUps,
        Action onUsps,
        Action onFedEx,
        Action onOnTrac,
        Action onLaserShip,
        Action onWalmartGround,
        Action onOther,
        Action<string> otherwise)
    {
        if (this == Ups) onUps();
        else if (this == Usps) onUsps();
        else if (this == FedEx) onFedEx();
        else if (this == OnTrac) onOnTrac();
        else if (this == LaserShip) onLaserShip();
        else if (this == WalmartGround) onWalmartGround();
        else if (this == Other) onOther();
        else otherwise(Value);
    }
}
