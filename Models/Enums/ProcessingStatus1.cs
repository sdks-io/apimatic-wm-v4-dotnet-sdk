using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Current processing status of the feed
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ProcessingStatus1>))]
public sealed record ProcessingStatus1 : StringEnum<ProcessingStatus1>
{
    private ProcessingStatus1(string value) : base(value)
    {
    }

    public static readonly ProcessingStatus1 Received = new("RECEIVED");

    public static readonly ProcessingStatus1 InProgress = new("IN_PROGRESS");

    public static readonly ProcessingStatus1 Done = new("DONE");

    public static readonly ProcessingStatus1 Error = new("ERROR");

    public static ProcessingStatus1 FromValue(string value) => FromValueCore(value);
}
