using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Format>))]
public sealed record Format : OpenStringEnum<Format>
{
    private Format(string value) : base(value)
    {
    }

    public static readonly Format Pdf = new("PDF");

    public static readonly Format Png = new("PNG");

    public static readonly Format Zpl = new("ZPL");

    public static readonly Format Zpl300 = new("ZPL300");

    public static readonly Format ShippingServiceDefault = new("ShippingServiceDefault");

    public TResult Match<TResult>(Func<TResult> onPdf,
        Func<TResult> onPng,
        Func<TResult> onZpl,
        Func<TResult> onZpl300,
        Func<TResult> onShippingServiceDefault,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Pdf => onPdf(),
            _ when this == Png => onPng(),
            _ when this == Zpl => onZpl(),
            _ when this == Zpl300 => onZpl300(),
            _ when this == ShippingServiceDefault => onShippingServiceDefault(),
            _ => otherwise(Value)
        };

    public void Match(Action onPdf,
        Action onPng,
        Action onZpl,
        Action onZpl300,
        Action onShippingServiceDefault,
        Action<string> otherwise)
    {
        if (this == Pdf) onPdf();
        else if (this == Png) onPng();
        else if (this == Zpl) onZpl();
        else if (this == Zpl300) onZpl300();
        else if (this == ShippingServiceDefault) onShippingServiceDefault();
        else otherwise(Value);
    }
}
