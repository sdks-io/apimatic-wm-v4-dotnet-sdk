using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedStatus>))]
public sealed record FeedStatus : StringEnum<FeedStatus>
{
    private FeedStatus(string value) : base(value)
    {
    }

    public static readonly FeedStatus Received = new("RECEIVED");

    public static readonly FeedStatus InProgress = new("IN_PROGRESS");

    public static readonly FeedStatus Done = new("DONE");

    public static readonly FeedStatus Error = new("ERROR");

    public static FeedStatus FromValue(string value) => FromValueCore(value);
}
