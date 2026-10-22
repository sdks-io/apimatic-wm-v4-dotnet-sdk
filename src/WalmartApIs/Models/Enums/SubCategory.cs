using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Rich media sub-category that determines the required Visible block. Allowed values: <c>video</c>, <c>360_spin_image</c>.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<SubCategory>))]
public sealed record SubCategory : OpenStringEnum<SubCategory>
{
    private SubCategory(string value) : base(value)
    {
    }

    public static readonly SubCategory Video = new("video");

    public static readonly SubCategory _360SpinImage = new("360_spin_image");

    public TResult Match<TResult>(Func<TResult> onVideo,
        Func<TResult> on_360SpinImage,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Video => onVideo(),
            _ when this == _360SpinImage => on_360SpinImage(),
            _ => otherwise(Value)
        };

    public void Match(Action onVideo, Action on_360SpinImage, Action<string> otherwise)
    {
        if (this == Video) onVideo();
        else if (this == _360SpinImage) on_360SpinImage();
        else otherwise(Value);
    }
}
