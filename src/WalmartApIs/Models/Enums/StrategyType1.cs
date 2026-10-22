using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Strategy type supported for markets is Buy Box Price(for us and mx),External Price(for us and mx, ca),Competitive Price(for us and mx).&lt;br&gt;&lt;b style="color:green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<StrategyType1>))]
public sealed record StrategyType1 : OpenStringEnum<StrategyType1>
{
    private StrategyType1(string value) : base(value)
    {
    }

    public static readonly StrategyType1 BuyBoxPrice = new("Buy Box Price");

    public static readonly StrategyType1 ExternalPrice = new("External Price");

    public static readonly StrategyType1 CompetitivePrice = new("Competitive Price");

    public TResult Match<TResult>(Func<TResult> onBuyBoxPrice,
        Func<TResult> onExternalPrice,
        Func<TResult> onCompetitivePrice,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == BuyBoxPrice => onBuyBoxPrice(),
            _ when this == ExternalPrice => onExternalPrice(),
            _ when this == CompetitivePrice => onCompetitivePrice(),
            _ => otherwise(Value)
        };

    public void Match(Action onBuyBoxPrice, Action onExternalPrice, Action onCompetitivePrice, Action<string> otherwise)
    {
        if (this == BuyBoxPrice) onBuyBoxPrice();
        else if (this == ExternalPrice) onExternalPrice();
        else if (this == CompetitivePrice) onCompetitivePrice();
        else otherwise(Value);
    }
}
