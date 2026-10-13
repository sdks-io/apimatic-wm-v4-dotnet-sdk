using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IncludedDatum1>))]
public sealed record IncludedDatum1 : OpenStringEnum<IncludedDatum1>
{
    private IncludedDatum1(string value) : base(value)
    {
    }

    public static readonly IncludedDatum1 Summaries = new("summaries");

    public static readonly IncludedDatum1 Attributes = new("attributes");

    public static readonly IncludedDatum1 Issues = new("issues");

    public static readonly IncludedDatum1 Offers = new("offers");

    public static readonly IncludedDatum1 FulfillmentAvailability = new("fulfillmentAvailability");

    public static readonly IncludedDatum1 Procurement = new("procurement");

    public TResult Match<TResult>(Func<TResult> onSummaries,
        Func<TResult> onAttributes,
        Func<TResult> onIssues,
        Func<TResult> onOffers,
        Func<TResult> onFulfillmentAvailability,
        Func<TResult> onProcurement,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Summaries => onSummaries(),
            _ when this == Attributes => onAttributes(),
            _ when this == Issues => onIssues(),
            _ when this == Offers => onOffers(),
            _ when this == FulfillmentAvailability => onFulfillmentAvailability(),
            _ when this == Procurement => onProcurement(),
            _ => otherwise(Value)
        };

    public void Match(Action onSummaries,
        Action onAttributes,
        Action onIssues,
        Action onOffers,
        Action onFulfillmentAvailability,
        Action onProcurement,
        Action<string> otherwise)
    {
        if (this == Summaries) onSummaries();
        else if (this == Attributes) onAttributes();
        else if (this == Issues) onIssues();
        else if (this == Offers) onOffers();
        else if (this == FulfillmentAvailability) onFulfillmentAvailability();
        else if (this == Procurement) onProcurement();
        else otherwise(Value);
    }
}
