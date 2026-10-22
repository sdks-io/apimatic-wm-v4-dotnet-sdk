using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Risk level as per Walmart standards
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RiskLevel>))]
public sealed record RiskLevel : OpenStringEnum<RiskLevel>
{
    private RiskLevel(string value) : base(value)
    {
    }

    public static readonly RiskLevel MeetsStandard = new("Meets standard");

    public static readonly RiskLevel Monitor = new("Monitor");

    public static readonly RiskLevel Urgent = new("Urgent");

    public TResult Match<TResult>(Func<TResult> onMeetsStandard,
        Func<TResult> onMonitor,
        Func<TResult> onUrgent,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == MeetsStandard => onMeetsStandard(),
            _ when this == Monitor => onMonitor(),
            _ when this == Urgent => onUrgent(),
            _ => otherwise(Value)
        };

    public void Match(Action onMeetsStandard, Action onMonitor, Action onUrgent, Action<string> otherwise)
    {
        if (this == MeetsStandard) onMeetsStandard();
        else if (this == Monitor) onMonitor();
        else if (this == Urgent) onUrgent();
        else otherwise(Value);
    }
}
