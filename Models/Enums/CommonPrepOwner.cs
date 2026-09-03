using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The owner of the preparations, if special preparations are required.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonPrepOwner>))]
public sealed record CommonPrepOwner : StringEnum<CommonPrepOwner>
{
    private CommonPrepOwner(string value) : base(value)
    {
    }

    public static readonly CommonPrepOwner Seller = new("SELLER");

    public static readonly CommonPrepOwner None = new("NONE");

    public static CommonPrepOwner FromValue(string value) => FromValueCore(value);
}
