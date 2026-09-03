using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether the item is available for shipping now, or on a known or an unknown date in the future.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AvailabilityType>))]
public sealed record AvailabilityType : StringEnum<AvailabilityType>
{
    private AvailabilityType(string value) : base(value)
    {
    }

    public static readonly AvailabilityType Now = new("NOW");

    public static readonly AvailabilityType FutureWithoutDate = new("FUTURE_WITHOUT_DATE");

    public static readonly AvailabilityType FutureWithDate = new("FUTURE_WITH_DATE");

    public static AvailabilityType FromValue(string value) => FromValueCore(value);
}
