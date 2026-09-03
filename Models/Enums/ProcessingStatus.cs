using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ProcessingStatus>))]
public sealed record ProcessingStatus : StringEnum<ProcessingStatus>
{
    private ProcessingStatus(string value) : base(value)
    {
    }

    public static readonly ProcessingStatus InQueue = new("IN_QUEUE");

    public static readonly ProcessingStatus InProgress = new("IN_PROGRESS");

    public static readonly ProcessingStatus Cancelled = new("CANCELLED");

    public static readonly ProcessingStatus Done = new("DONE");

    public static readonly ProcessingStatus Fatal = new("FATAL");

    public static ProcessingStatus FromValue(string value) => FromValueCore(value);
}
