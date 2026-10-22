using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Tags that indicate why an item is in demand, helping sellers quickly assess customer interest and competitive trends. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<SalesInsights2>))]
public sealed record SalesInsights2 : OpenStringEnum<SalesInsights2>
{
    private SalesInsights2(string value) : base(value)
    {
    }

    public static readonly SalesInsights2 BestSeller = new("BEST_SELLER");

    public static readonly SalesInsights2 Trending = new("TRENDING");

    public static readonly SalesInsights2 FirstMover = new("FIRST_MOVER");

    public static readonly SalesInsights2 HighlySearched = new("HIGHLY_SEARCHED");

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
