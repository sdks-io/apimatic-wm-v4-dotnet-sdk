using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WmMarket>))]
public sealed record WmMarket : OpenStringEnum<WmMarket>
{
    private WmMarket(string value) : base(value)
    {
    }

    public static readonly WmMarket Us = new("us");

    public TResult Match<TResult>(Func<TResult> onUs, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Us => onUs(),
            _ => otherwise(Value)
        };

    public void Match(Action onUs, Action<string> otherwise)
    {
        if (this == Us) onUs();
        else otherwise(Value);
    }
}
