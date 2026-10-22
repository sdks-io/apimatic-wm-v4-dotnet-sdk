using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Allowed Values
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FeedType>))]
public sealed record FeedType : OpenStringEnum<FeedType>
{
    private FeedType(string value) : base(value)
    {
    }

    public static readonly FeedType FitmentAces = new("FITMENT_ACES");

    public static readonly FeedType FitmentPies = new("FITMENT_PIES");

    public TResult Match<TResult>(Func<TResult> onFitmentAces,
        Func<TResult> onFitmentPies,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == FitmentAces => onFitmentAces(),
            _ when this == FitmentPies => onFitmentPies(),
            _ => otherwise(Value)
        };

    public void Match(Action onFitmentAces, Action onFitmentPies, Action<string> otherwise)
    {
        if (this == FitmentAces) onFitmentAces();
        else if (this == FitmentPies) onFitmentPies();
        else otherwise(Value);
    }
}
