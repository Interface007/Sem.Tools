namespace Sem.Tools
{
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.Json;

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
                stringBuilder.Append(num.ToString("x2", CultureInfo.InvariantCulture));
            }

            return stringBuilder.ToString();
        }

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
    }
}