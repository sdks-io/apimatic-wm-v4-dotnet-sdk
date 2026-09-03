using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Compression applied to the document; decompress before parsing if present
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CompressionAlgorithm>))]
public sealed record CompressionAlgorithm : StringEnum<CompressionAlgorithm>
{
    private CompressionAlgorithm(string value) : base(value)
    {
    }

    public static readonly CompressionAlgorithm Gzip = new("GZIP");

    public static CompressionAlgorithm FromValue(string value) => FromValueCore(value);
}
