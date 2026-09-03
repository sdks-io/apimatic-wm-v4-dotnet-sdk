using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CodeChallengeMethod>))]
public sealed record CodeChallengeMethod : StringEnum<CodeChallengeMethod>
{
    private CodeChallengeMethod(string value) : base(value)
    {
    }

    public static readonly CodeChallengeMethod S256 = new("S256");

    public static CodeChallengeMethod FromValue(string value) => FromValueCore(value);
}
