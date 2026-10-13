using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<LabelFormat>))]
public sealed record LabelFormat : OpenStringEnum<LabelFormat>
{
    private LabelFormat(string value) : base(value)
    {
    }

    public static readonly LabelFormat Pdf = new("PDF");

    public static readonly LabelFormat Png = new("PNG");

    public static readonly LabelFormat Zpl = new("ZPL");

    public static readonly LabelFormat Zpl300 = new("ZPL300");

    public static readonly LabelFormat ShippingServiceDefault = new("ShippingServiceDefault");

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
