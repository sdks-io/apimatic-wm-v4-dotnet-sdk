using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SortBy>))]
public sealed record SortBy : OpenStringEnum<SortBy>
{
    private SortBy(string value) : base(value)
    {
    }

    public static readonly SortBy ClaimDate = new("claimDate");

    public TResult Match<TResult>(Func<TResult> onClaimDate, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ClaimDate => onClaimDate(),
            _ => otherwise(Value)
        };

    public void Match(Action onClaimDate, Action<string> otherwise)
    {
        if (this == ClaimDate) onClaimDate();
        else otherwise(Value);
    }
}
