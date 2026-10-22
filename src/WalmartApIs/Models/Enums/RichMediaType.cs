using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<RichMediaType>))]
public sealed record RichMediaType : OpenStringEnum<RichMediaType>
{
    private RichMediaType(string value) : base(value)
    {
    }

    public static readonly RichMediaType Images360 = new("IMAGES360");

    public static readonly RichMediaType Video = new("VIDEO");

    public TResult Match<TResult>(Func<TResult> onImages360, Func<TResult> onVideo, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Images360 => onImages360(),
            _ when this == Video => onVideo(),
            _ => otherwise(Value)
        };

    public void Match(Action onImages360, Action onVideo, Action<string> otherwise)
    {
        if (this == Images360) onImages360();
        else if (this == Video) onVideo();
        else otherwise(Value);
    }
}
