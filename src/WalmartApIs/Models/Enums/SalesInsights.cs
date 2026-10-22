using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Tags that indicate why an item is in demand, helping sellers quickly assess customer interest and competitive signal. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<SalesInsights>))]
public sealed record SalesInsights : OpenStringEnum<SalesInsights>
{
    private SalesInsights(string value) : base(value)
    {
    }

    public static readonly SalesInsights BestSeller = new("BEST_SELLER");

    public static readonly SalesInsights Trending = new("TRENDING");

    public static readonly SalesInsights FirstMover = new("FIRST_MOVER");

    public static readonly SalesInsights HighlySearched = new("HIGHLY_SEARCHED");

    public TResult Match<TResult>(Func<TResult> onBestSeller,
        Func<TResult> onTrending,
        Func<TResult> onFirstMover,
        Func<TResult> onHighlySearched,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == BestSeller => onBestSeller(),
            _ when this == Trending => onTrending(),
            _ when this == FirstMover => onFirstMover(),
            _ when this == HighlySearched => onHighlySearched(),
            _ => otherwise(Value)
        };

    public void Match(Action onBestSeller,
        Action onTrending,
        Action onFirstMover,
        Action onHighlySearched,
        Action<string> otherwise)
    {
        if (this == BestSeller) onBestSeller();
        else if (this == Trending) onTrending();
        else if (this == FirstMover) onFirstMover();
        else if (this == HighlySearched) onHighlySearched();
        else otherwise(Value);
    }
}
