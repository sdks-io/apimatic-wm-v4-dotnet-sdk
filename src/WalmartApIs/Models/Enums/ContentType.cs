using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// MIME type of the uploaded feed content.
/// If omitted, the server infers from the file's Content-Type in the multipart header.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ContentType>))]
public sealed record ContentType : OpenStringEnum<ContentType>
{
    private ContentType(string value) : base(value)
    {
    }

    public static readonly ContentType TextXmlCharsetUtf8 = new("text/xml; charset=UTF-8");

    public static readonly ContentType TextTabSeparatedValuesCharsetUtf8 = new(
        "text/tab-separated-values; charset=UTF-8");

    public static readonly ContentType ApplicationJsonCharsetUtf8 = new("application/json; charset=UTF-8");

    public TResult Match<TResult>(Func<TResult> onTextXmlCharsetUtf8,
        Func<TResult> onTextTabSeparatedValuesCharsetUtf8,
        Func<TResult> onApplicationJsonCharsetUtf8,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == TextXmlCharsetUtf8 => onTextXmlCharsetUtf8(),
            _ when this == TextTabSeparatedValuesCharsetUtf8 => onTextTabSeparatedValuesCharsetUtf8(),
            _ when this == ApplicationJsonCharsetUtf8 => onApplicationJsonCharsetUtf8(),
            _ => otherwise(Value)
        };

    public void Match(Action onTextXmlCharsetUtf8,
        Action onTextTabSeparatedValuesCharsetUtf8,
        Action onApplicationJsonCharsetUtf8,
        Action<string> otherwise)
    {
        if (this == TextXmlCharsetUtf8) onTextXmlCharsetUtf8();
        else if (this == TextTabSeparatedValuesCharsetUtf8) onTextTabSeparatedValuesCharsetUtf8();
        else if (this == ApplicationJsonCharsetUtf8) onApplicationJsonCharsetUtf8();
        else otherwise(Value);
    }
}
