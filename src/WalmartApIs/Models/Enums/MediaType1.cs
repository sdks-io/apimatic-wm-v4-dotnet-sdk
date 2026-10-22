using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Media type as recorded for this specific item linkage.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<MediaType1>))]
public sealed record MediaType1 : OpenStringEnum<MediaType1>
{
    private MediaType1(string value) : base(value)
    {
    }

    public static readonly MediaType1 Video = new("VIDEO");

    public static readonly MediaType1 Images360 = new("IMAGES360");

    public TResult Match<TResult>(Func<TResult> onVideo, Func<TResult> onImages360, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Video => onVideo(),
            _ when this == Images360 => onImages360(),
            _ => otherwise(Value)
        };

    public void Match(Action onVideo, Action onImages360, Action<string> otherwise)
    {
        if (this == Video) onVideo();
        else if (this == Images360) onImages360();
        else otherwise(Value);
    }
}
