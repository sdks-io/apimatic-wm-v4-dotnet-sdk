using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<DocumentType2>))]
public sealed record DocumentType2 : OpenStringEnum<DocumentType2>
{
    private DocumentType2(string value) : base(value)
    {
    }

    public static readonly DocumentType2 ProofOfDamagedItem = new("PROOF_OF_DAMAGED_ITEM");

    public static readonly DocumentType2 Invoice = new("INVOICE");

    public static readonly DocumentType2 Other = new("OTHER");

    public static readonly DocumentType2 Ppod = new("PPOD");

    public TResult Match<TResult>(Func<TResult> onProofOfDamagedItem,
        Func<TResult> onInvoice,
        Func<TResult> onOther,
        Func<TResult> onPpod,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ProofOfDamagedItem => onProofOfDamagedItem(),
            _ when this == Invoice => onInvoice(),
            _ when this == Other => onOther(),
            _ when this == Ppod => onPpod(),
            _ => otherwise(Value)
        };

    public void Match(Action onProofOfDamagedItem,
        Action onInvoice,
        Action onOther,
        Action onPpod,
        Action<string> otherwise)
    {
        if (this == ProofOfDamagedItem) onProofOfDamagedItem();
        else if (this == Invoice) onInvoice();
        else if (this == Other) onOther();
        else if (this == Ppod) onPpod();
        else otherwise(Value);
    }
}
