using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Duration category of the investigation.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Name>))]
public sealed record Name : StringEnum<Name>
{
    private Name(string value) : base(value)
    {
    }

    public static readonly Name ResearchingQuantityInShortTerm = new("researchingQuantityInShortTerm");

    public static readonly Name ResearchingQuantityInMidTerm = new("researchingQuantityInMidTerm");

    public static readonly Name ResearchingQuantityInLongTerm = new("researchingQuantityInLongTerm");

    public static Name FromValue(string value) => FromValueCore(value);
}
