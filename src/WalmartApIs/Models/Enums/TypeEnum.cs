using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Recommendation category.
/// <list type="bullet">
///   <item><description><b>BUDGET</b>: Recommended budget adjustment (daily or total)</description></item>
///   <item><description><b>BIDDING_STRATEGY</b>: Recommended change to bidding strategy</description></item>
/// </list>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TypeEnum>))]
public sealed record TypeEnum : OpenStringEnum<TypeEnum>
{
    private TypeEnum(string value) : base(value)
    {
    }

    public static readonly TypeEnum Budget = new("BUDGET");

    public static readonly TypeEnum BiddingStrategy = new("BIDDING_STRATEGY");

    public TResult Match<TResult>(Func<TResult> onBudget,
        Func<TResult> onBiddingStrategy,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Budget => onBudget(),
            _ when this == BiddingStrategy => onBiddingStrategy(),
            _ => otherwise(Value)
        };

    public void Match(Action onBudget, Action onBiddingStrategy, Action<string> otherwise)
    {
        if (this == Budget) onBudget();
        else if (this == BiddingStrategy) onBiddingStrategy();
        else otherwise(Value);
    }
}
