using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Aggregation level for metrics. Determines which identifier fields are populated in response.
/// <list type="bullet">
///   <item><description><b>CAMPAIGN</b>: Only <c>campaignId</c> populated (<c>adGroupId</c>, <c>creativeId</c> will be null)</description></item>
///   <item><description><b>ADGROUP</b>: <c>campaignId</c> and <c>adGroupId</c> populated (<c>creativeId</c> will be null)</description></item>
///   <item><description><b>CREATIVE</b>: All IDs populated (<c>campaignId</c>, <c>adGroupId</c>, <c>creativeId</c>)</description></item>
/// </list>
/// <para>
/// <b>Default</b>: <c>CREATIVE</c> (when not specified)
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PerformanceBy>))]
public sealed record PerformanceBy : OpenStringEnum<PerformanceBy>
{
    private PerformanceBy(string value) : base(value)
    {
    }

    public static readonly PerformanceBy Campaign = new("CAMPAIGN");

    public static readonly PerformanceBy Adgroup = new("ADGROUP");

    public static readonly PerformanceBy Creative = new("CREATIVE");

    public TResult Match<TResult>(Func<TResult> onCampaign,
        Func<TResult> onAdgroup,
        Func<TResult> onCreative,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Campaign => onCampaign(),
            _ when this == Adgroup => onAdgroup(),
            _ when this == Creative => onCreative(),
            _ => otherwise(Value)
        };

    public void Match(Action onCampaign, Action onAdgroup, Action onCreative, Action<string> otherwise)
    {
        if (this == Campaign) onCampaign();
        else if (this == Adgroup) onAdgroup();
        else if (this == Creative) onCreative();
        else otherwise(Value);
    }
}
