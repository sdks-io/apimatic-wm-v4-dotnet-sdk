using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Item availability status of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
/// <para>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | EXISTING_IN_WALMART | Indicates that item is existing in Walmart. | string |
/// | NEW_TO_WALMART | Indicates that item is new to Walmart. | string |
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ItemAvailabilityStatus4>))]
public sealed record ItemAvailabilityStatus4 : OpenStringEnum<ItemAvailabilityStatus4>
{
    private ItemAvailabilityStatus4(string value) : base(value)
    {
    }

    public static readonly ItemAvailabilityStatus4 ExistingInWalmart = new("EXISTING_IN_WALMART");

    public static readonly ItemAvailabilityStatus4 NewToWalmart = new("NEW_TO_WALMART");

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
