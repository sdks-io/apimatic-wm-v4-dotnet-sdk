using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indication of how box content is meant to be provided.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonBoxContentInformationSource>))]
public sealed record CommonBoxContentInformationSource : StringEnum<CommonBoxContentInformationSource>
{
    private CommonBoxContentInformationSource(string value) : base(value)
    {
    }

    public static readonly CommonBoxContentInformationSource BoxContentProvided = new("BOX_CONTENT_PROVIDED");

    public static readonly CommonBoxContentInformationSource ManualProcess = new("MANUAL_PROCESS");

    public static readonly CommonBoxContentInformationSource Barcode2D = new("BARCODE_2D");

    public static CommonBoxContentInformationSource FromValue(string value) => FromValueCore(value);
}
