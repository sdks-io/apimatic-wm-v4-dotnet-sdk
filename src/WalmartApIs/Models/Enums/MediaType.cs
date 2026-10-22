using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Type of rich media asset. Determines the structure of the <c>richMediaAsset</c> object.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<MediaType>))]
public sealed record MediaType : OpenStringEnum<MediaType>
{
    private MediaType(string value) : base(value)
    {
    }

    public static readonly MediaType Video = new("VIDEO");

    public static readonly MediaType Images360 = new("IMAGES360");

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
