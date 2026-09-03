using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Type1>))]
public sealed record Type1 : StringEnum<Type1>
{
    private Type1(string value) : base(value)
    {
    }

    public static readonly Type1 Label = new("LABEL");

    public static readonly Type1 Receipt = new("RECEIPT");

    public static readonly Type1 CustomsForm = new("CUSTOMS_FORM");

    public static readonly Type1 CommercialInvoice = new("COMMERCIAL_INVOICE");

    public static Type1 FromValue(string value) => FromValueCore(value);
}
