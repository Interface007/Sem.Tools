namespace Sem.Tools
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// A JSON converter encrypting using DPAPI for the local machine and the current user.
    /// </summary>
    public sealed class EncryptionConverter : JsonConverter<string>
    {
        private static readonly byte[] OptionalEntropy = Encoding.UTF8.GetBytes("A83077DF396848909DAF55DF1204C3E8");

        private readonly Func<string, byte[]> encrypt = EncryptWithDpapi;

        private readonly Func<byte[], string> decrypt = DecryptWithDpapi;

        /// <summary>Reads and converts the JSON to type string.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>The converted value.</returns>
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => this.decrypt(Convert.FromBase64String(reader.GetString()));

        /// <summary>Writes a specified value as JSON.</summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The value to convert to JSON.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) => writer.WriteStringValue(Convert.ToBase64String(this.encrypt(value)));

        private static byte[] EncryptWithDpapi(string value)
        {
            return ProtectedData.Protect(Encoding.UTF8.GetBytes(value), OptionalEntropy, DataProtectionScope.CurrentUser);
        }

        private static string DecryptWithDpapi(byte[] data)
        {
            return Encoding.UTF8.GetString(ProtectedData.Unprotect(data, OptionalEntropy, DataProtectionScope.CurrentUser));
        }
    }
}