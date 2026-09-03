using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// MIME type of the uploaded feed content.
/// If omitted, the server infers from the file's Content-Type in the multipart header.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ContentType>))]
public sealed record ContentType : StringEnum<ContentType>
{
    private ContentType(string value) : base(value)
    {
    }

    public static readonly ContentType TextXmlCharsetUtf8 = new("text/xml; charset=UTF-8");

    public static readonly ContentType TextTabSeparatedValuesCharsetUtf8 = new("text/tab-separated-values; charset=UTF-8");

    public static readonly ContentType ApplicationJsonCharsetUtf8 = new("application/json; charset=UTF-8");

    public static ContentType FromValue(string value) => FromValueCore(value);
}
