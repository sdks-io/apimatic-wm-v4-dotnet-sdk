using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indication of how box content is meant to be provided.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonBoxContentInformationSource>))]
public sealed record CommonBoxContentInformationSource : OpenStringEnum<CommonBoxContentInformationSource>
{
    private CommonBoxContentInformationSource(string value) : base(value)
    {
    }

    public static readonly CommonBoxContentInformationSource BoxContentProvided = new("BOX_CONTENT_PROVIDED");

    public static readonly CommonBoxContentInformationSource ManualProcess = new("MANUAL_PROCESS");

    public static readonly CommonBoxContentInformationSource Barcode2D = new("BARCODE_2D");

    public TResult Match<TResult>(Func<TResult> onBoxContentProvided,
        Func<TResult> onManualProcess,
        Func<TResult> onBarcode2D,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == BoxContentProvided => onBoxContentProvided(),
            _ when this == ManualProcess => onManualProcess(),
            _ when this == Barcode2D => onBarcode2D(),
            _ => otherwise(Value)
        };

    public void Match(Action onBoxContentProvided, Action onManualProcess, Action onBarcode2D, Action<string> otherwise)
    {
        if (this == BoxContentProvided) onBoxContentProvided();
        else if (this == ManualProcess) onManualProcess();
        else if (this == Barcode2D) onBarcode2D();
        else otherwise(Value);
    }
}
