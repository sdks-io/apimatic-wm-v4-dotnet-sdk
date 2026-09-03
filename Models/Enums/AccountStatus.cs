using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<AccountStatus>))]
public sealed record AccountStatus : StringEnum<AccountStatus>
{
    private AccountStatus(string value) : base(value)
    {
    }

    public static readonly AccountStatus Active = new("Active");

    public static readonly AccountStatus Inactive = new("Inactive");

    public static readonly AccountStatus Suspended = new("Suspended");

    public static AccountStatus FromValue(string value) => FromValueCore(value);
}
