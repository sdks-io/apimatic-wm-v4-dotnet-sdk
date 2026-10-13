using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// A constraint that applies to all owners. If no constraint is specified, defer to any individual owner constraints.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonAllOwnersConstraint>))]
public sealed record CommonAllOwnersConstraint : OpenStringEnum<CommonAllOwnersConstraint>
{
    private CommonAllOwnersConstraint(string value) : base(value)
    {
    }

    public static readonly CommonAllOwnersConstraint MustMatch = new("MUST_MATCH");

    public TResult Match<TResult>(Func<TResult> onMustMatch, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == MustMatch => onMustMatch(),
            _ => otherwise(Value)
        };

    public void Match(Action onMustMatch, Action<string> otherwise)
    {
        if (this == MustMatch) onMustMatch();
        else otherwise(Value);
    }
}
