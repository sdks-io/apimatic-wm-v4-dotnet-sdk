using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Top-level category of regulation that applies. NOT_REGULATED
/// means no verification is required and the rest of the fields
/// are informational only.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RegulatedCategory>))]
public sealed record RegulatedCategory : StringEnum<RegulatedCategory>
{
    private RegulatedCategory(string value) : base(value)
    {
    }

    public static readonly RegulatedCategory NotRegulated = new("NOT_REGULATED");

    public static readonly RegulatedCategory Alcohol = new("ALCOHOL");

    public static readonly RegulatedCategory Tobacco = new("TOBACCO");

    public static readonly RegulatedCategory AgeRestricted = new("AGE_RESTRICTED");

    public static readonly RegulatedCategory Pharmacy = new("PHARMACY");

    public static RegulatedCategory FromValue(string value) => FromValueCore(value);
}
