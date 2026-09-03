using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FileType>))]
public sealed record FileType : StringEnum<FileType>
{
    private FileType(string value) : base(value)
    {
    }

    public static readonly FileType ApplicationPdf = new("application/pdf");

    public static readonly FileType ApplicationZpl = new("application/zpl");

    public static readonly FileType ImagePng = new("image/png");

    public static FileType FromValue(string value) => FromValueCore(value);
}
