using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Status of the issue submitted.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status>))]
public sealed record Status : OpenStringEnum<Status>
{
    private Status(string value) : base(value)
    {
    }

    public static readonly Status Acknowledged = new("ACKNOWLEDGED");

    public TResult Match<TResult>(Func<TResult> onAcknowledged, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Acknowledged => onAcknowledged(),
            _ => otherwise(Value)
        };

    public void Match(Action onAcknowledged, Action<string> otherwise)
    {
        if (this == Acknowledged) onAcknowledged();
        else otherwise(Value);
    }
}
