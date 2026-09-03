using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// A constraint that applies to all owners. If no constraint is specified, defer to any individual owner constraints.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonAllOwnersConstraint>))]
public sealed record CommonAllOwnersConstraint : StringEnum<CommonAllOwnersConstraint>
{
    private CommonAllOwnersConstraint(string value) : base(value)
    {
    }

    public static readonly CommonAllOwnersConstraint MustMatch = new("MUST_MATCH");

    public static CommonAllOwnersConstraint FromValue(string value) => FromValueCore(value);
}
