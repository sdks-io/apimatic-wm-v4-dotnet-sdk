using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Specifies who will label the items. Options include <c>SELLER</c> and <c>NONE</c>., The owner of the preparations, if special preparations are required., Specifies who will label the items. Options include <c>SELLER</c> and <c>NONE</c>., The owner of the preparations, if special preparations are required., Specifies who will label the items. Options include <c>SELLER</c> and <c>NONE</c>., The owner of the preparations, if special preparations are required.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonLabelOwner>))]
public sealed record CommonLabelOwner : StringEnum<CommonLabelOwner>
{
    private CommonLabelOwner(string value) : base(value)
    {
    }

    public static readonly CommonLabelOwner Seller = new("SELLER");

    public static readonly CommonLabelOwner None = new("NONE");

    public static CommonLabelOwner FromValue(string value) => FromValueCore(value);
}
