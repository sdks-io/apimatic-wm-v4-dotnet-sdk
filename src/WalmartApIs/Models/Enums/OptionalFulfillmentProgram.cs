using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Optional fulfillment program override for WFS items.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OptionalFulfillmentProgram>))]
public sealed record OptionalFulfillmentProgram : OpenStringEnum<OptionalFulfillmentProgram>
{
    private OptionalFulfillmentProgram(string value) : base(value)
    {
    }

    public static readonly OptionalFulfillmentProgram WfsStandard = new("WFS_STANDARD");

    public static readonly OptionalFulfillmentProgram WfsExpedited = new("WFS_EXPEDITED");

    public TResult Match<TResult>(Func<TResult> onWfsStandard,
        Func<TResult> onWfsExpedited,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == WfsStandard => onWfsStandard(),
            _ when this == WfsExpedited => onWfsExpedited(),
            _ => otherwise(Value)
        };

    public void Match(Action onWfsStandard, Action onWfsExpedited, Action<string> otherwise)
    {
        if (this == WfsStandard) onWfsStandard();
        else if (this == WfsExpedited) onWfsExpedited();
        else otherwise(Value);
    }
}
