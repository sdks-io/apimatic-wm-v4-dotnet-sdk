using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SellerStatus>))]
public sealed record SellerStatus : OpenStringEnum<SellerStatus>
{
    private SellerStatus(string value) : base(value)
    {
    }

    public static readonly SellerStatus Active = new("Active");

    public static readonly SellerStatus Inactive = new("Inactive");

    public static readonly SellerStatus Suspended = new("Suspended");

    public static readonly SellerStatus PendingApproval = new("PendingApproval");

    public TResult Match<TResult>(Func<TResult> onActive,
        Func<TResult> onInactive,
        Func<TResult> onSuspended,
        Func<TResult> onPendingApproval,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Active => onActive(),
            _ when this == Inactive => onInactive(),
            _ when this == Suspended => onSuspended(),
            _ when this == PendingApproval => onPendingApproval(),
            _ => otherwise(Value)
        };

    public void Match(Action onActive,
        Action onInactive,
        Action onSuspended,
        Action onPendingApproval,
        Action<string> otherwise)
    {
        if (this == Active) onActive();
        else if (this == Inactive) onInactive();
        else if (this == Suspended) onSuspended();
        else if (this == PendingApproval) onPendingApproval();
        else otherwise(Value);
    }
}
