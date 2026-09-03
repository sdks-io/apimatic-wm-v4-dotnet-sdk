using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ContentType1>))]
public sealed record ContentType1 : StringEnum<ContentType1>
{
    private ContentType1(string value) : base(value)
    {
    }

    public static readonly ContentType1 TextXmlCharsetUtf8 = new("text/xml; charset=UTF-8");

    public static readonly ContentType1 TextTabSeparatedValuesCharsetUtf8 = new("text/tab-separated-values; charset=UTF-8");

    public static readonly ContentType1 ApplicationJsonCharsetUtf8 = new("application/json; charset=UTF-8");

    public static readonly ContentType1 ApplicationOctetStream = new("application/octet-stream");

    public static ContentType1 FromValue(string value) => FromValueCore(value);
}
