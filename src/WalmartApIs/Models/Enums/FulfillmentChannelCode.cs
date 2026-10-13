using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentChannelCode>))]
public sealed record FulfillmentChannelCode : OpenStringEnum<FulfillmentChannelCode>
{
    private FulfillmentChannelCode(string value) : base(value)
    {
    }

    public static readonly FulfillmentChannelCode Default = new("DEFAULT");

    public static readonly FulfillmentChannelCode Wfs = new("WFS");

    public TResult Match<TResult>(Func<TResult> onDefault, Func<TResult> onWfs, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Default => onDefault(),
            _ when this == Wfs => onWfs(),
            _ => otherwise(Value)
        };

    public void Match(Action onDefault, Action onWfs, Action<string> otherwise)
    {
        if (this == Default) onDefault();
        else if (this == Wfs) onWfs();
        else otherwise(Value);
    }
}
