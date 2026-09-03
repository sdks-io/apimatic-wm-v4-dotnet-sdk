using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SellerStatus>))]
public sealed record SellerStatus : StringEnum<SellerStatus>
{
    private SellerStatus(string value) : base(value)
    {
    }

    public static readonly SellerStatus Active = new("Active");

    public static readonly SellerStatus Inactive = new("Inactive");

    public static readonly SellerStatus Suspended = new("Suspended");

    public static readonly SellerStatus PendingApproval = new("PendingApproval");

    public static SellerStatus FromValue(string value) => FromValueCore(value);
}
