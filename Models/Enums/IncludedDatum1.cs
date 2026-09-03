using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IncludedDatum1>))]
public sealed record IncludedDatum1 : StringEnum<IncludedDatum1>
{
    private IncludedDatum1(string value) : base(value)
    {
    }

    public static readonly IncludedDatum1 Summaries = new("summaries");

    public static readonly IncludedDatum1 Attributes = new("attributes");

    public static readonly IncludedDatum1 Issues = new("issues");

    public static readonly IncludedDatum1 Offers = new("offers");

    public static readonly IncludedDatum1 FulfillmentAvailability = new("fulfillmentAvailability");

    public static readonly IncludedDatum1 Procurement = new("procurement");

    public static IncludedDatum1 FromValue(string value) => FromValueCore(value);
}
