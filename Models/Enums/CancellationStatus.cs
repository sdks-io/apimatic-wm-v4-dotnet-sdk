using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CancellationStatus>))]
public sealed record CancellationStatus : StringEnum<CancellationStatus>
{
    private CancellationStatus(string value) : base(value)
    {
    }

    public static readonly CancellationStatus Cancelled = new("CANCELLED");

    public static readonly CancellationStatus Pending = new("PENDING");

    public static readonly CancellationStatus Rejected = new("REJECTED");

    public static CancellationStatus FromValue(string value) => FromValueCore(value);
}
