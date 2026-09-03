using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Patch operation type (JSON Patch)
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Op>))]
public sealed record Op : StringEnum<Op>
{
    private Op(string value) : base(value)
    {
    }

    public static readonly Op Add = new("add");

    public static readonly Op Replace = new("replace");

    public static readonly Op Delete = new("delete");

    public static Op FromValue(string value) => FromValueCore(value);
}
