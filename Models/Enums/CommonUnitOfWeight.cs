using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Unit of the weight being measured.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonUnitOfWeight>))]
public sealed record CommonUnitOfWeight : StringEnum<CommonUnitOfWeight>
{
    private CommonUnitOfWeight(string value) : base(value)
    {
    }

    public static readonly CommonUnitOfWeight Lb = new("LB");

    public static readonly CommonUnitOfWeight Kg = new("KG");

    public static CommonUnitOfWeight FromValue(string value) => FromValueCore(value);
}
