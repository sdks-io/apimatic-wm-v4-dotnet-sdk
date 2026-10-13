using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether to request Consumer or Business offers. Default is Consumer.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CustomerType>))]
public sealed record CustomerType : OpenStringEnum<CustomerType>
{
    private CustomerType(string value) : base(value)
    {
    }

    public static readonly CustomerType Consumer = new("Consumer");

    public static readonly CustomerType Business = new("Business");

    public TResult Match<TResult>(Func<TResult> onConsumer,
        Func<TResult> onBusiness,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Consumer => onConsumer(),
            _ when this == Business => onBusiness(),
            _ => otherwise(Value)
        };

    public void Match(Action onConsumer, Action onBusiness, Action<string> otherwise)
    {
        if (this == Consumer) onConsumer();
        else if (this == Business) onBusiness();
        else otherwise(Value);
    }
}
