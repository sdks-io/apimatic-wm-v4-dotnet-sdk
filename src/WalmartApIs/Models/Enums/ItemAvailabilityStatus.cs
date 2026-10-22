using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Item availability status of the recommended item.
/// <para>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | EXISTING_IN_WALMART | Indicates that item is existing in Walmart. | string |
/// | NEW_TO_WALMART | Indicates that item is new to Walmart. | string |
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ItemAvailabilityStatus>))]
public sealed record ItemAvailabilityStatus : OpenStringEnum<ItemAvailabilityStatus>
{
    private ItemAvailabilityStatus(string value) : base(value)
    {
    }

    public static readonly ItemAvailabilityStatus ExistingInWalmart = new("EXISTING_IN_WALMART");

    public static readonly ItemAvailabilityStatus NewToWalmart = new("NEW_TO_WALMART");

    public TResult Match<TResult>(Func<TResult> onExistingInWalmart,
        Func<TResult> onNewToWalmart,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ExistingInWalmart => onExistingInWalmart(),
            _ when this == NewToWalmart => onNewToWalmart(),
            _ => otherwise(Value)
        };

    public void Match(Action onExistingInWalmart, Action onNewToWalmart, Action<string> otherwise)
    {
        if (this == ExistingInWalmart) onExistingInWalmart();
        else if (this == NewToWalmart) onNewToWalmart();
        else otherwise(Value);
    }
}
