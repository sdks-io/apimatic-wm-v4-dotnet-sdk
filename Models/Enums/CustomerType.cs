using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether to request Consumer or Business offers. Default is Consumer.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CustomerType>))]
public sealed record CustomerType : StringEnum<CustomerType>
{
    private CustomerType(string value) : base(value)
    {
    }

    public static readonly CustomerType Consumer = new("Consumer");

    public static readonly CustomerType Business = new("Business");

    public static CustomerType FromValue(string value) => FromValueCore(value);
}
