// <copyright file="InheritanceConverter.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Serializes inherited objects in properties. Normally, only the properties of the type explicitly
    /// declared on the property is being serialized - with this attribute the property value is fully serialized.
    /// </summary>
    /// <typeparam name="TType">The type to handle with this converter.</typeparam>
    public sealed class InheritanceConverter<TType> : JsonConverter<TType>
        where TType : class
    {
        /// <summary>Reads and converts the JSON to type <typeparamref name="TType" />.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>The converted value.</returns>
        public override TType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // "$type":
            reader.Read();
            reader.GetString();

            // "{type name}",
            reader.Read();
            var typeName = reader.GetString();
            typeName.MustNotBeNull("type cannot be read");

            var returnType = Type.GetType(typeName);
            typeName.MustNotBeNull("Problem creating type info for " + typeName + ".");

            // "Data":
            reader.Read();
            reader.GetString();

            // now the object
            reader.Read();
            var deserialize = (TType)JsonSerializer.Deserialize(ref reader, returnType);

            // forward to next element
            reader.Read();
            return deserialize;
        }

        /// <summary>Writes a specified value as JSON.</summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The value to convert to JSON.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, TType value, JsonSerializerOptions options)
        {
            writer.MustNotBeNull(nameof(writer));
            value.MustNotBeNull(nameof(value));
            writer.WriteStartObject();

            writer.WritePropertyName("$type");

            var typeName = $"{value.GetType().FullName}, {value.GetType().Assembly.GetName().Name}";
            writer.WriteStringValue(typeName);

            writer.WriteStartObject("Data");
            using var doc = JsonDocument.Parse(value.ToJson());
            foreach (var property in doc.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }

            writer.WriteEndObject();

            writer.WriteEndObject();
        }
    }
}