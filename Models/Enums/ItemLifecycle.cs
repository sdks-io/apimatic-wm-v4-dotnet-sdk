using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Lifecycle state of the item in the Walmart catalog.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ItemLifecycle>))]
public sealed record ItemLifecycle : StringEnum<ItemLifecycle>
{
    private ItemLifecycle(string value) : base(value)
    {
    }

    public static readonly ItemLifecycle Active = new("Active");

    public static readonly ItemLifecycle Retired = new("Retired");

    public static readonly ItemLifecycle Archived = new("Archived");

    public static ItemLifecycle FromValue(string value) => FromValueCore(value);
}
