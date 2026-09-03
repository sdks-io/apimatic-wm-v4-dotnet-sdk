using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Current listing state of the item on Walmart.com.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PublishingStatus>))]
public sealed record PublishingStatus : StringEnum<PublishingStatus>
{
    private PublishingStatus(string value) : base(value)
    {
    }

    public static readonly PublishingStatus Published = new("Published");

    public static readonly PublishingStatus Unpublished = new("Unpublished");

    public static readonly PublishingStatus Processing = new("Processing");

    public static readonly PublishingStatus Stage = new("Stage");

    public static readonly PublishingStatus Error = new("Error");

    public static readonly PublishingStatus WfsIneligible = new("WfsIneligible");

    public static PublishingStatus FromValue(string value) => FromValueCore(value);
}
