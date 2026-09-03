using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The status of an operation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonOperationStatus>))]
public sealed record CommonOperationStatus : StringEnum<CommonOperationStatus>
{
    private CommonOperationStatus(string value) : base(value)
    {
    }

    public static readonly CommonOperationStatus Success = new("SUCCESS");

    public static readonly CommonOperationStatus Failed = new("FAILED");

    public static readonly CommonOperationStatus InProgress = new("IN_PROGRESS");

    public static CommonOperationStatus FromValue(string value) => FromValueCore(value);
}
