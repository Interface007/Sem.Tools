// <copyright file="Extensions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools
{
    using System;
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.Json;

    using JetBrains.Annotations;
    using Microsoft;

    /// <summary>
    /// Very basic extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Calculates a simple SHA256 hash from a string.
        /// </summary>
        /// <param name="value">The string to be hashed.</param>
        /// <returns>The has as HEX encoded data.</returns>
        public static string Hash(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            }

            var stringBuilder = new StringBuilder();
            using var shA256 = SHA256.Create();

            foreach (var num in shA256.ComputeHash(Encoding.UTF8.GetBytes(value)))
            {
                _ = stringBuilder.Append(num.ToString("x2", CultureInfo.InvariantCulture));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when passing NULL or an empty string to <paramref name="value" />.
        /// </summary>
        /// <param name="value">The value that must not be null or en empty string.</param>
        /// <param name="nameOfValue">The name of the value (usually the name of the parameter).</param>
        /// <returns> The original value of <paramref name="value"/>. </returns>
        [ContractAnnotation("value: null => halt")]
        public static string MustNotBeNullOrEmpty([NotNull][ValidatedNotNull]this string value, string nameOfValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameOfValue);
            }

            return value;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when passing NULL values to <paramref name="value" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The value that must not be null.</param>
        /// <param name="nameOfValue">The name of the value (usually the name of the parameter).</param>
        /// <returns> The original value of <paramref name="value"/>. </returns>
        [ContractAnnotation("value: null => halt")]
        public static T MustNotBeNull<T>([NoEnumeration][NotNull][ValidatedNotNull] this T value, string nameOfValue)
            where T : class
            => value ?? throw new ArgumentNullException(nameOfValue);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when passing NULL values to <paramref name="value" />.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The value that must not be null.</param>
        /// <param name="nameOfValue">The name of the value (usually the name of the parameter).</param>
        /// <returns> The NON-Null value of <paramref name="value"/>. </returns>
        [ContractAnnotation("value: null => halt")]
        public static T MustNotBeNull<T>([ValidatedNotNull] this T? value, string nameOfValue)
            where T : struct
            => (object)value != null ? value.Value : throw new ArgumentNullException(nameOfValue);

        /// <summary>
        /// Extends all objects to have a simple JsonSerialization method.
        /// </summary>
        /// <typeparam name="T">The type of the object to be serialized.</typeparam>
        /// <param name="value">The value to be serialized.</param>
        /// <returns>A JSON string.</returns>
        public static string ToJson<T>(this T value)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            // Since serialization using the generic method JsonSerializer.Serialize<T> does
            // only serialize the properties of T, we use the non-generic method and determine
            // the type here explicitly.
            return JsonSerializer.Serialize(value, value.GetType(), serializeOptions);
        }

        /// <summary>
        /// Extends all strings to have a simple JsonDeSerialization method.
        /// </summary>
        /// <typeparam name="T">The type of the object to be serialized.</typeparam>
        /// <param name="value">The value to be serialized.</param>
        /// <returns>A JSON string.</returns>
        public static T FromJson<T>(this string value) => JsonSerializer.Deserialize<T>(value);
    }
}