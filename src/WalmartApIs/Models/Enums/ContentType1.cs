using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ContentType1>))]
public sealed record ContentType1 : OpenStringEnum<ContentType1>
{
    private ContentType1(string value) : base(value)
    {
    }

    public static readonly ContentType1 TextXmlCharsetUtf8 = new("text/xml; charset=UTF-8");

    public static readonly ContentType1 TextTabSeparatedValuesCharsetUtf8 = new(
        "text/tab-separated-values; charset=UTF-8");

    public static readonly ContentType1 ApplicationJsonCharsetUtf8 = new("application/json; charset=UTF-8");

    public static readonly ContentType1 ApplicationOctetStream = new("application/octet-stream");

    public TResult Match<TResult>(Func<TResult> onTextXmlCharsetUtf8,
        Func<TResult> onTextTabSeparatedValuesCharsetUtf8,
        Func<TResult> onApplicationJsonCharsetUtf8,
        Func<TResult> onApplicationOctetStream,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == TextXmlCharsetUtf8 => onTextXmlCharsetUtf8(),
            _ when this == TextTabSeparatedValuesCharsetUtf8 => onTextTabSeparatedValuesCharsetUtf8(),
            _ when this == ApplicationJsonCharsetUtf8 => onApplicationJsonCharsetUtf8(),
            _ when this == ApplicationOctetStream => onApplicationOctetStream(),
            _ => otherwise(Value)
        };

    public void Match(Action onTextXmlCharsetUtf8,
        Action onTextTabSeparatedValuesCharsetUtf8,
        Action onApplicationJsonCharsetUtf8,
        Action onApplicationOctetStream,
        Action<string> otherwise)
    {
        if (this == TextXmlCharsetUtf8) onTextXmlCharsetUtf8();
        else if (this == TextTabSeparatedValuesCharsetUtf8) onTextTabSeparatedValuesCharsetUtf8();
        else if (this == ApplicationJsonCharsetUtf8) onApplicationJsonCharsetUtf8();
        else if (this == ApplicationOctetStream) onApplicationOctetStream();
        else otherwise(Value);
    }
}
