using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<RequestType>))]
public sealed record RequestType : OpenStringEnum<RequestType>
{
    private RequestType(string value) : base(value)
    {
    }

    public static readonly RequestType WalmartPlusSff = new("WALMART_PLUS_SFF");

    public TResult Match<TResult>(Func<TResult> onWalmartPlusSff, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == WalmartPlusSff => onWalmartPlusSff(),
            _ => otherwise(Value)
        };

    public void Match(Action onWalmartPlusSff, Action<string> otherwise)
    {
        if (this == WalmartPlusSff) onWalmartPlusSff();
        else otherwise(Value);
    }
}
