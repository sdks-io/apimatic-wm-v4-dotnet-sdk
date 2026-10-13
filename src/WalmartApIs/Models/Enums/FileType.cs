using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FileType>))]
public sealed record FileType : OpenStringEnum<FileType>
{
    private FileType(string value) : base(value)
    {
    }

    public static readonly FileType ApplicationPdf = new("application/pdf");

    public static readonly FileType ApplicationZpl = new("application/zpl");

    public static readonly FileType ImagePng = new("image/png");

    public TResult Match<TResult>(Func<TResult> onApplicationPdf,
        Func<TResult> onApplicationZpl,
        Func<TResult> onImagePng,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ApplicationPdf => onApplicationPdf(),
            _ when this == ApplicationZpl => onApplicationZpl(),
            _ when this == ImagePng => onImagePng(),
            _ => otherwise(Value)
        };

    public void Match(Action onApplicationPdf, Action onApplicationZpl, Action onImagePng, Action<string> otherwise)
    {
        if (this == ApplicationPdf) onApplicationPdf();
        else if (this == ApplicationZpl) onApplicationZpl();
        else if (this == ImagePng) onImagePng();
        else otherwise(Value);
    }
}
