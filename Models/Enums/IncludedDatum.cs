using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IncludedDatum>))]
public sealed record IncludedDatum : StringEnum<IncludedDatum>
{
    private IncludedDatum(string value) : base(value)
    {
    }

    public static readonly IncludedDatum Attributes = new("attributes");

    public static readonly IncludedDatum Dimensions = new("dimensions");

    public static readonly IncludedDatum Identifiers = new("identifiers");

    public static readonly IncludedDatum Images = new("images");

    public static readonly IncludedDatum ProductTypes = new("productTypes");

    public static readonly IncludedDatum Relationships = new("relationships");

    public static readonly IncludedDatum SalesRanks = new("salesRanks");

    public static IncludedDatum FromValue(string value) => FromValueCore(value);
}
