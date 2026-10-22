using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models.AnyOf;

/// <summary>
/// The market specific locale. Allowed values by market include: es for MX and CL, and en and fr for CA.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(Locale1Converter))]
public record Locale1
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<IReadOnlyList<string>> _listOfStringValue;

    private Locale1(Optional<string> stringValue, Optional<IReadOnlyList<string>> listOfStringValue)
    {
        _stringValue = stringValue;
        _listOfStringValue = listOfStringValue;
    }

    public static Locale1 String(string value) => new(Optional<string>.Some(value), default);

    public static Locale1 ListOfString(IReadOnlyList<string> value) =>
        new(default, Optional<IReadOnlyList<string>>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public bool TryGetListOfString(out IReadOnlyList<string> value) => _listOfStringValue.TryGetValue(out value);

    public static implicit operator Locale1(string value) => String(value);
}

file sealed class Locale1Converter : JsonConverter<Locale1>
{
    public override Locale1 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.ValueKind == JsonValueKind.String)
        {
            var value = root.GetString()!;
            return Locale1.String(value);
        }
        if (JsonSerializer.TryDeserialize<IReadOnlyList<string>>(root, options, out var listOfStringValue))
        {
            return Locale1.ListOfString(listOfStringValue);
        }
        throw new JsonException($"JSON does not match string or IReadOnlyList<string> schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Locale1 value, JsonSerializerOptions options)
    {
        if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else if (value.TryGetListOfString(out var listOfStringValue))
        {
            JsonSerializer.Serialize(writer, listOfStringValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(Locale1)} contains no valid value to serialize.");
        }
    }
}
