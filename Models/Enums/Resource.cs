using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Resource>))]
public sealed record Resource : StringEnum<Resource>
{
    private Resource(string value) : base(value)
    {
    }

    public static readonly Resource Feeds = new("feeds");

    public static readonly Resource Reports = new("reports");

    public static Resource FromValue(string value) => FromValueCore(value);
}
