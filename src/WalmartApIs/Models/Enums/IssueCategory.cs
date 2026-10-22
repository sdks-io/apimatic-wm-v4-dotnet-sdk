using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Overall SEM eligibility status derived from all issues affecting this item.
/// <list type="bullet">
///   <item><description><b>NO_ISSUES</b>: Item has no SEM issues and can be advertised on search engines with full visibility</description></item>
///   <item><description><b>LIMITED</b>: Item has issues that reduce its visibility or performance in Search Engine Marketing</description></item>
///   <item><description><b>BLOCKED</b>: Item has critical issues that completely prevent it from being advertised on search engines</description></item>
/// </list>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<IssueCategory>))]
public sealed record IssueCategory : OpenStringEnum<IssueCategory>
{
    private IssueCategory(string value) : base(value)
    {
    }

    public static readonly IssueCategory NoIssues = new("NO_ISSUES");

    public static readonly IssueCategory Limited = new("LIMITED");

    public static readonly IssueCategory Blocked = new("BLOCKED");

    public TResult Match<TResult>(Func<TResult> onNoIssues,
        Func<TResult> onLimited,
        Func<TResult> onBlocked,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == NoIssues => onNoIssues(),
            _ when this == Limited => onLimited(),
            _ when this == Blocked => onBlocked(),
            _ => otherwise(Value)
        };

    public void Match(Action onNoIssues, Action onLimited, Action onBlocked, Action<string> otherwise)
    {
        if (this == NoIssues) onNoIssues();
        else if (this == Limited) onLimited();
        else if (this == Blocked) onBlocked();
        else otherwise(Value);
    }
}
