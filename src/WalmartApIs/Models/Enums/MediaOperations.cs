using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Operation type. Allowed values: <c>Delink</c> and <c>null</c>(empty). Set to <c>Delink</c> to remove the GTIN association from this asset. Set to <c>null</c> (empty) for create/edit operations.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<MediaOperations>))]
public sealed record MediaOperations : OpenStringEnum<MediaOperations>
{
    private MediaOperations(string value) : base(value)
    {
    }

    public static readonly MediaOperations Delink = new("Delink");

    public TResult Match<TResult>(Func<TResult> onDelink, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Delink => onDelink(),
            _ => otherwise(Value)
        };

    public void Match(Action onDelink, Action<string> otherwise)
    {
        if (this == Delink) onDelink();
        else otherwise(Value);
    }
}
