using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status2>))]
public sealed record Status2 : OpenStringEnum<Status2>
{
    private Status2(string value) : base(value)
    {
    }

    public static readonly Status2 Rejected = new("REJECTED");

    public static readonly Status2 Approved = new("APPROVED");

    public static readonly Status2 NewItems = new("NEW_ITEMS");

    public TResult Match<TResult>(Func<TResult> onRejected,
        Func<TResult> onApproved,
        Func<TResult> onNewItems,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Rejected => onRejected(),
            _ when this == Approved => onApproved(),
            _ when this == NewItems => onNewItems(),
            _ => otherwise(Value)
        };

    public void Match(Action onRejected, Action onApproved, Action onNewItems, Action<string> otherwise)
    {
        if (this == Rejected) onRejected();
        else if (this == Approved) onApproved();
        else if (this == NewItems) onNewItems();
        else otherwise(Value);
    }
}
