using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Type of item identifier.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<IdType>))]
public sealed record IdType : StringEnum<IdType>
{
    private IdType(string value) : base(value)
    {
    }

    public static readonly IdType WalmartItemId = new("WalmartItemId");

    public static readonly IdType SellerSku = new("SellerSKU");

    public static IdType FromValue(string value) => FromValueCore(value);
}
