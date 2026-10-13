using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<StandardIdForLabel>))]
public sealed record StandardIdForLabel : OpenStringEnum<StandardIdForLabel>
{
    private StandardIdForLabel(string value) : base(value)
    {
    }

    public static readonly StandardIdForLabel WalmartOrderId = new("WalmartOrderId");

    public TResult Match<TResult>(Func<TResult> onWalmartOrderId, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == WalmartOrderId => onWalmartOrderId(),
            _ => otherwise(Value)
        };

    public void Match(Action onWalmartOrderId, Action<string> otherwise)
    {
        if (this == WalmartOrderId) onWalmartOrderId();
        else otherwise(Value);
    }
}
