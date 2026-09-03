using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// A constraint that can apply to an individual owner.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonOwnerConstraint>))]
public sealed record CommonOwnerConstraint : StringEnum<CommonOwnerConstraint>
{
    private CommonOwnerConstraint(string value) : base(value)
    {
    }

    public static readonly CommonOwnerConstraint SellerOnly = new("SELLER_ONLY");

    public static readonly CommonOwnerConstraint NoneOnly = new("NONE_ONLY");

    public static CommonOwnerConstraint FromValue(string value) => FromValueCore(value);
}
