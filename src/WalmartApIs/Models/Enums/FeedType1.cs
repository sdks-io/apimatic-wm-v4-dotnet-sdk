using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedType1>))]
public sealed record FeedType1 : OpenStringEnum<FeedType1>
{
    private FeedType1(string value) : base(value)
    {
    }

    public static readonly FeedType1 Inventory = new("inventory");

    public static readonly FeedType1 MpInventory = new("MP_INVENTORY");

    public TResult Match<TResult>(Func<TResult> onInventory,
        Func<TResult> onMpInventory,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Inventory => onInventory(),
            _ when this == MpInventory => onMpInventory(),
            _ => otherwise(Value)
        };

    public void Match(Action onInventory, Action onMpInventory, Action<string> otherwise)
    {
        if (this == Inventory) onInventory();
        else if (this == MpInventory) onMpInventory();
        else otherwise(Value);
    }
}
