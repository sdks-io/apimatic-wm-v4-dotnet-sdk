using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Format1>))]
public sealed record Format1 : OpenStringEnum<Format1>
{
    private Format1(string value) : base(value)
    {
    }

    public static readonly Format1 Pdf = new("PDF");

    public static readonly Format1 Png = new("PNG");

    public static readonly Format1 Zpl203 = new("ZPL203");

    public static readonly Format1 Zpl300 = new("ZPL300");

    public TResult Match<TResult>(Func<TResult> onPdf,
        Func<TResult> onPng,
        Func<TResult> onZpl203,
        Func<TResult> onZpl300,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Pdf => onPdf(),
            _ when this == Png => onPng(),
            _ when this == Zpl203 => onZpl203(),
            _ when this == Zpl300 => onZpl300(),
            _ => otherwise(Value)
        };

    public void Match(Action onPdf, Action onPng, Action onZpl203, Action onZpl300, Action<string> otherwise)
    {
        if (this == Pdf) onPdf();
        else if (this == Png) onPng();
        else if (this == Zpl203) onZpl203();
        else if (this == Zpl300) onZpl300();
        else otherwise(Value);
    }
}
