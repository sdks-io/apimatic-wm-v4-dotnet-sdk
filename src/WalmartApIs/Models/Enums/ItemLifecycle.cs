using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Lifecycle state of the item in the Walmart catalog.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ItemLifecycle>))]
public sealed record ItemLifecycle : OpenStringEnum<ItemLifecycle>
{
    private ItemLifecycle(string value) : base(value)
    {
    }

    public static readonly ItemLifecycle Active = new("Active");

    public static readonly ItemLifecycle Retired = new("Retired");

    public static readonly ItemLifecycle Archived = new("Archived");

    public TResult Match<TResult>(Func<TResult> onActive,
        Func<TResult> onRetired,
        Func<TResult> onArchived,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Active => onActive(),
            _ when this == Retired => onRetired(),
            _ when this == Archived => onArchived(),
            _ => otherwise(Value)
        };

    public void Match(Action onActive, Action onRetired, Action onArchived, Action<string> otherwise)
    {
        if (this == Active) onActive();
        else if (this == Retired) onRetired();
        else if (this == Archived) onArchived();
        else otherwise(Value);
    }
}
