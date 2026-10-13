using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<AccountStatus>))]
public sealed record AccountStatus : OpenStringEnum<AccountStatus>
{
    private AccountStatus(string value) : base(value)
    {
    }

    public static readonly AccountStatus Active = new("Active");

    public static readonly AccountStatus Inactive = new("Inactive");

    public static readonly AccountStatus Suspended = new("Suspended");

    public TResult Match<TResult>(Func<TResult> onActive,
        Func<TResult> onInactive,
        Func<TResult> onSuspended,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Active => onActive(),
            _ when this == Inactive => onInactive(),
            _ when this == Suspended => onSuspended(),
            _ => otherwise(Value)
        };

    public void Match(Action onActive, Action onInactive, Action onSuspended, Action<string> otherwise)
    {
        if (this == Active) onActive();
        else if (this == Inactive) onInactive();
        else if (this == Suspended) onSuspended();
        else otherwise(Value);
    }
}
