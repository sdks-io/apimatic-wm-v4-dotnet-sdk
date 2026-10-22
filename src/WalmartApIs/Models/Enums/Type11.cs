using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Document category; one of PROOF_OF_DAMAGED_ITEM, INVOICE, OTHER, PPOD.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Type11>))]
public sealed record Type11 : OpenStringEnum<Type11>
{
    private Type11(string value) : base(value)
    {
    }

    public static readonly Type11 ProofOfDamagedItem = new("PROOF_OF_DAMAGED_ITEM");

    public static readonly Type11 Invoice = new("INVOICE");

    public static readonly Type11 Other = new("OTHER");

    public static readonly Type11 Ppod = new("PPOD");

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
