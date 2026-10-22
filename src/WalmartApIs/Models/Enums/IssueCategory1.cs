using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Issue severity category.
/// <list type="bullet">
///   <item><description><b>BLOCKED</b>: Item cannot be advertised</description></item>
///   <item><description><b>LIMITED</b>: Item has reduced visibility or performance</description></item>
///   <item><description><b>NO_ISSUES</b>: Item has no SEM eligibility issues</description></item>
/// </list>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<IssueCategory1>))]
public sealed record IssueCategory1 : OpenStringEnum<IssueCategory1>
{
    private IssueCategory1(string value) : base(value)
    {
    }

    public static readonly IssueCategory1 Blocked = new("BLOCKED");

    public static readonly IssueCategory1 Limited = new("LIMITED");

    public static readonly IssueCategory1 NoIssues = new("NO_ISSUES");

    public TResult Match<TResult>(Func<TResult> onBlocked,
        Func<TResult> onLimited,
        Func<TResult> onNoIssues,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Blocked => onBlocked(),
            _ when this == Limited => onLimited(),
            _ when this == NoIssues => onNoIssues(),
            _ => otherwise(Value)
        };

    public void Match(Action onBlocked, Action onLimited, Action onNoIssues, Action<string> otherwise)
    {
        if (this == Blocked) onBlocked();
        else if (this == Limited) onLimited();
        else if (this == NoIssues) onNoIssues();
        else otherwise(Value);
    }
}
