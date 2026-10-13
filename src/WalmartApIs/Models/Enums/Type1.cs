using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Type1>))]
public sealed record Type1 : OpenStringEnum<Type1>
{
    private Type1(string value) : base(value)
    {
    }

    public static readonly Type1 Label = new("LABEL");

    public static readonly Type1 Receipt = new("RECEIPT");

    public static readonly Type1 CustomsForm = new("CUSTOMS_FORM");

    public static readonly Type1 CommercialInvoice = new("COMMERCIAL_INVOICE");

    public TResult Match<TResult>(Func<TResult> onLabel,
        Func<TResult> onReceipt,
        Func<TResult> onCustomsForm,
        Func<TResult> onCommercialInvoice,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Label => onLabel(),
            _ when this == Receipt => onReceipt(),
            _ when this == CustomsForm => onCustomsForm(),
            _ when this == CommercialInvoice => onCommercialInvoice(),
            _ => otherwise(Value)
        };

    public void Match(Action onLabel,
        Action onReceipt,
        Action onCustomsForm,
        Action onCommercialInvoice,
        Action<string> otherwise)
    {
        if (this == Label) onLabel();
        else if (this == Receipt) onReceipt();
        else if (this == CustomsForm) onCustomsForm();
        else if (this == CommercialInvoice) onCommercialInvoice();
        else otherwise(Value);
    }
}
