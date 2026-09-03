using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The Ship Node appointment slot for the transportation option.
/// </summary>
public record CommonAppointmentSlot
{
    /// <summary>
    /// An identifier to a self-ship appointment slot.
    /// </summary>
    [JsonPropertyName("slotId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string SlotId { get; init; }

    /// <summary>
    /// An appointment slot time with start and end.
    /// </summary>
    [JsonPropertyName("slotTime")]
    public required CommonAppointmentSlotTime SlotTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
