using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SortOrder>))]
public sealed record SortOrder : OpenStringEnum<SortOrder>
{
    private SortOrder(string value) : base(value)
    {
    }

    public static readonly SortOrder Acs = new("ACS");

    public static readonly SortOrder Desc = new("DESC");

    public TResult Match<TResult>(Func<TResult> onAcs, Func<TResult> onDesc, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Acs => onAcs(),
            _ when this == Desc => onDesc(),
            _ => otherwise(Value)
        };

    public void Match(Action onAcs, Action onDesc, Action<string> otherwise)
    {
        if (this == Acs) onAcs();
        else if (this == Desc) onDesc();
        else otherwise(Value);
    }
}
