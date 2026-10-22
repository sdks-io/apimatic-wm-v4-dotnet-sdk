using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Rules>))]
public sealed record Rules : OpenStringEnum<Rules>
{
    private Rules(string value) : base(value)
    {
    }

    public static readonly Rules FullAccess = new("full_access");

    public static readonly Rules ViewOnly = new("view_only");

    public static readonly Rules NoAccess = new("no_access");

    public TResult Match<TResult>(Func<TResult> onFullAccess,
        Func<TResult> onViewOnly,
        Func<TResult> onNoAccess,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == FullAccess => onFullAccess(),
            _ when this == ViewOnly => onViewOnly(),
            _ when this == NoAccess => onNoAccess(),
            _ => otherwise(Value)
        };

    public void Match(Action onFullAccess, Action onViewOnly, Action onNoAccess, Action<string> otherwise)
    {
        if (this == FullAccess) onFullAccess();
        else if (this == ViewOnly) onViewOnly();
        else if (this == NoAccess) onNoAccess();
        else otherwise(Value);
    }
}
