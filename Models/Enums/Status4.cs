using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Outcome of the fee estimate.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status4>))]
public sealed record Status4 : StringEnum<Status4>
{
    private Status4(string value) : base(value)
    {
    }

    public static readonly Status4 Success = new("Success");

    public static readonly Status4 ClientError = new("ClientError");

    public static readonly Status4 ServiceError = new("ServiceError");

    public static Status4 FromValue(string value) => FromValueCore(value);
}
