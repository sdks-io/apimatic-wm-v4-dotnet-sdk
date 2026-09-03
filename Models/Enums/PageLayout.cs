using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<PageLayout>))]
public sealed record PageLayout : StringEnum<PageLayout>
{
    private PageLayout(string value) : base(value)
    {
    }

    public static readonly PageLayout Default = new("DEFAULT");

    public static readonly PageLayout FourInOne = new("FOUR_IN_ONE");

    public static PageLayout FromValue(string value) => FromValueCore(value);
}
