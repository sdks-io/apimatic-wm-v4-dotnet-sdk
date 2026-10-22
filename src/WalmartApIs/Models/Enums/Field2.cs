using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Field by which the filtering is to be done.
/// <para>
/// <b>Supported fields</b>:
/// - <c>issues</c>: Filter by specific issue types (For example, <c>ITEM_OUT_OF_STOCK</c>, <c>TITLE_TOO_LONG</c>)
/// - <c>issueCategory</c>: Filter by issue severity category (<c>LIMITED</c>, <c>BLOCKED</c>, <c>NO_ISSUES</c>)
/// - <c>itemId</c>: Filter by Walmart item IDs (numeric strings). Currently filters within items in active SEM campaigns. *In a future release, this will also support items not yet associated with any campaign.*
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Field2>))]
public sealed record Field2 : OpenStringEnum<Field2>
{
    private Field2(string value) : base(value)
    {
    }

    public static readonly Field2 Issues = new("issues");

    public static readonly Field2 IssueCategory = new("issueCategory");

    public static readonly Field2 ItemId = new("itemId");

    public TResult Match<TResult>(Func<TResult> onIssues,
        Func<TResult> onIssueCategory,
        Func<TResult> onItemId,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Issues => onIssues(),
            _ when this == IssueCategory => onIssueCategory(),
            _ when this == ItemId => onItemId(),
            _ => otherwise(Value)
        };

    public void Match(Action onIssues, Action onIssueCategory, Action onItemId, Action<string> otherwise)
    {
        if (this == Issues) onIssues();
        else if (this == IssueCategory) onIssueCategory();
        else if (this == ItemId) onItemId();
        else otherwise(Value);
    }
}
