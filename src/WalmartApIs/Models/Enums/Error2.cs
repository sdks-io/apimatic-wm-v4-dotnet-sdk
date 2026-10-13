using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Machine-readable error code.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Error2>))]
public sealed record Error2 : OpenStringEnum<Error2>
{
    private Error2(string value) : base(value)
    {
    }

    public static readonly Error2 InvalidRedirectUri = new("invalid_redirect_uri");

    public static readonly Error2 InvalidClientMetadata = new("invalid_client_metadata");

    public static readonly Error2 InvalidSoftwareStatement = new("invalid_software_statement");

    public static readonly Error2 UnapprovedSoftwareStatement = new("unapproved_software_statement");

    public TResult Match<TResult>(Func<TResult> onInvalidRedirectUri,
        Func<TResult> onInvalidClientMetadata,
        Func<TResult> onInvalidSoftwareStatement,
        Func<TResult> onUnapprovedSoftwareStatement,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == InvalidRedirectUri => onInvalidRedirectUri(),
            _ when this == InvalidClientMetadata => onInvalidClientMetadata(),
            _ when this == InvalidSoftwareStatement => onInvalidSoftwareStatement(),
            _ when this == UnapprovedSoftwareStatement => onUnapprovedSoftwareStatement(),
            _ => otherwise(Value)
        };

    public void Match(Action onInvalidRedirectUri,
        Action onInvalidClientMetadata,
        Action onInvalidSoftwareStatement,
        Action onUnapprovedSoftwareStatement,
        Action<string> otherwise)
    {
        if (this == InvalidRedirectUri) onInvalidRedirectUri();
        else if (this == InvalidClientMetadata) onInvalidClientMetadata();
        else if (this == InvalidSoftwareStatement) onInvalidSoftwareStatement();
        else if (this == UnapprovedSoftwareStatement) onUnapprovedSoftwareStatement();
        else otherwise(Value);
    }
}
