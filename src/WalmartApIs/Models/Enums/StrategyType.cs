using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Strategy type supported for markets is Buy Box Price(for us and mx), External Price(for US, MX and CA), Competitive Price(for us and mx).&lt;br&gt;&lt;b style="color:green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<StrategyType>))]
public sealed record StrategyType : OpenStringEnum<StrategyType>
{
    private StrategyType(string value) : base(value)
    {
    }

    public static readonly StrategyType BuyBoxPrice = new("Buy Box Price");

    public static readonly StrategyType ExternalPrice = new("External Price");

    public static readonly StrategyType CompetitivePrice = new("Competitive Price");

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
