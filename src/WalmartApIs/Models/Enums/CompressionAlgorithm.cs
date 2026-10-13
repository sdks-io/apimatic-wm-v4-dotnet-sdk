using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Compression applied to the document; decompress before parsing if present
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CompressionAlgorithm>))]
public sealed record CompressionAlgorithm : OpenStringEnum<CompressionAlgorithm>
{
    private CompressionAlgorithm(string value) : base(value)
    {
    }

    public static readonly CompressionAlgorithm Gzip = new("GZIP");

    public TResult Match<TResult>(Func<TResult> onGzip, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Gzip => onGzip(),
            _ => otherwise(Value)
        };

    public void Match(Action onGzip, Action<string> otherwise)
    {
        if (this == Gzip) onGzip();
        else otherwise(Value);
    }
}
