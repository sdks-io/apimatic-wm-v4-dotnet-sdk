using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The HTTP method associated with the individual APIs being called as part of the batch request.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<HttpMethodEnum>))]
public sealed record HttpMethodEnum : StringEnum<HttpMethodEnum>
{
    private HttpMethodEnum(string value) : base(value)
    {
    }

    public static readonly HttpMethodEnum Get = new("GET");

    public static readonly HttpMethodEnum Put = new("PUT");

    public static readonly HttpMethodEnum Patch = new("PATCH");

    public static readonly HttpMethodEnum Delete = new("DELETE");

    public static readonly HttpMethodEnum Post = new("POST");

    public static HttpMethodEnum FromValue(string value) => FromValueCore(value);
}
